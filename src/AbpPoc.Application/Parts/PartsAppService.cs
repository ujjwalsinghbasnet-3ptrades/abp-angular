using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using AbpPoc.Permissions;
using AbpPoc.Parts;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using AbpPoc.Shared;

namespace AbpPoc.Parts
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AbpPocPermissions.Parts.Default)]
    public abstract class PartsAppServiceBase : AbpPocAppService
    {
        protected IDistributedCache<PartDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IPartRepository _partRepository;
        protected PartManager _partManager;

        public PartsAppServiceBase(IPartRepository partRepository, PartManager partManager, IDistributedCache<PartDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _partRepository = partRepository;
            _partManager = partManager;

        }

        public virtual async Task<PagedResultDto<PartDto>> GetListAsync(GetPartsInput input)
        {
            var totalCount = await _partRepository.GetCountAsync(input.FilterText, input.name, input.description, input.partNumber, input.cageCode, input.toNumber, input.distributionStatement, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl);
            var items = await _partRepository.GetListAsync(input.FilterText, input.name, input.description, input.partNumber, input.cageCode, input.toNumber, input.distributionStatement, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PartDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Part>, List<PartDto>>(items)
            };
        }

        public virtual async Task<PartDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Part, PartDto>(await _partRepository.GetAsync(id));
        }

        [Authorize(AbpPocPermissions.Parts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _partRepository.DeleteAsync(id);
        }

        [Authorize(AbpPocPermissions.Parts.Create)]
        public virtual async Task<PartDto> CreateAsync(PartCreateDto input)
        {

            var part = await _partManager.CreateAsync(
            input.name, input.partNumber, input.cageCode, input.toNumber, input.nsn, input.description, input.distributionStatement, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.imageUrl
            );

            return ObjectMapper.Map<Part, PartDto>(part);
        }

        [Authorize(AbpPocPermissions.Parts.Edit)]
        public virtual async Task<PartDto> UpdateAsync(Guid id, PartUpdateDto input)
        {

            var part = await _partManager.UpdateAsync(
            id,
            input.name, input.partNumber, input.cageCode, input.toNumber, input.nsn, input.description, input.distributionStatement, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.imageUrl, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Part, PartDto>(part);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PartExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _partRepository.GetListAsync(input.FilterText, input.name, input.description, input.partNumber, input.cageCode, input.toNumber, input.distributionStatement, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Part>, List<PartExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Parts.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(AbpPocPermissions.Parts.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> partIds)
        {
            await _partRepository.DeleteManyAsync(partIds);
        }

        [Authorize(AbpPocPermissions.Parts.Delete)]
        public virtual async Task DeleteAllAsync(GetPartsInput input)
        {
            await _partRepository.DeleteAllAsync(input.FilterText, input.name, input.description, input.partNumber, input.cageCode, input.toNumber, input.distributionStatement, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl);
        }
        public virtual async Task<AbpPoc.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new PartDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new AbpPoc.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}