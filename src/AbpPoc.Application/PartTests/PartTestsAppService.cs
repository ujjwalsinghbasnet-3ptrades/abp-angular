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
using AbpPoc.PartTests;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using AbpPoc.Shared;

namespace AbpPoc.PartTests
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AbpPocPermissions.PartTests.Default)]
    public abstract class PartTestsAppServiceBase : AbpPocAppService
    {
        protected IDistributedCache<PartTestDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IPartTestRepository _partTestRepository;
        protected PartTestManager _partTestManager;

        public PartTestsAppServiceBase(IPartTestRepository partTestRepository, PartTestManager partTestManager, IDistributedCache<PartTestDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _partTestRepository = partTestRepository;
            _partTestManager = partTestManager;

        }

        public virtual async Task<PagedResultDto<PartTestDto>> GetListAsync(GetPartTestsInput input)
        {
            var totalCount = await _partTestRepository.GetCountAsync(input.FilterText, input.partNumber, input.name, input.cageCode, input.distributionStatement, input.toNumber, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl);
            var items = await _partTestRepository.GetListAsync(input.FilterText, input.partNumber, input.name, input.cageCode, input.distributionStatement, input.toNumber, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PartTestDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PartTest>, List<PartTestDto>>(items)
            };
        }

        public virtual async Task<PartTestDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<PartTest, PartTestDto>(await _partTestRepository.GetAsync(id));
        }

        [Authorize(AbpPocPermissions.PartTests.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _partTestRepository.DeleteAsync(id);
        }

        [Authorize(AbpPocPermissions.PartTests.Create)]
        public virtual async Task<PartTestDto> CreateAsync(PartTestCreateDto input)
        {

            var partTest = await _partTestManager.CreateAsync(
            input.partNumber, input.name, input.cageCode, input.distributionStatement, input.toNumber, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl
            );

            return ObjectMapper.Map<PartTest, PartTestDto>(partTest);
        }

        [Authorize(AbpPocPermissions.PartTests.Edit)]
        public virtual async Task<PartTestDto> UpdateAsync(Guid id, PartTestUpdateDto input)
        {

            var partTest = await _partTestManager.UpdateAsync(
            id,
            input.partNumber, input.name, input.cageCode, input.distributionStatement, input.toNumber, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PartTest, PartTestDto>(partTest);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PartTestExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _partTestRepository.GetListAsync(input.FilterText, input.partNumber, input.name, input.cageCode, input.distributionStatement, input.toNumber, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<PartTest>, List<PartTestExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PartTests.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(AbpPocPermissions.PartTests.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> parttestIds)
        {
            await _partTestRepository.DeleteManyAsync(parttestIds);
        }

        [Authorize(AbpPocPermissions.PartTests.Delete)]
        public virtual async Task DeleteAllAsync(GetPartTestsInput input)
        {
            await _partTestRepository.DeleteAllAsync(input.FilterText, input.partNumber, input.name, input.cageCode, input.distributionStatement, input.toNumber, input.smr, input.niin, input.fsc, input.wuc, input.uoc, input.uniqueId, input.nsn, input.imageUrl);
        }
        public virtual async Task<AbpPoc.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new PartTestDownloadTokenCacheItem { Token = token },
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