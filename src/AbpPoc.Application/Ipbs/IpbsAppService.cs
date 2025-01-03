using AbpPoc.Shared;
using AbpPoc.Parts;
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
using AbpPoc.Ipbs;

namespace AbpPoc.Ipbs
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AbpPocPermissions.Ipbs.Default)]
    public abstract class IpbsAppServiceBase : AbpPocAppService
    {

        protected IIpbRepository _ipbRepository;
        protected IpbManager _ipbManager;

        protected IRepository<AbpPoc.Parts.Part, Guid> _partRepository;

        public IpbsAppServiceBase(IIpbRepository ipbRepository, IpbManager ipbManager, IRepository<AbpPoc.Parts.Part, Guid> partRepository)
        {

            _ipbRepository = ipbRepository;
            _ipbManager = ipbManager; _partRepository = partRepository;

        }

        public virtual async Task<PagedResultDto<IpbWithNavigationPropertiesDto>> GetListAsync(GetIpbsInput input)
        {
            var totalCount = await _ipbRepository.GetCountAsync(input.FilterText, input.figureName, input.figureNumber, input.toNumber, input.indentureLevel, input.sourceId, input.relatedId);
            var items = await _ipbRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.figureName, input.figureNumber, input.toNumber, input.indentureLevel, input.sourceId, input.relatedId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<IpbWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<IpbWithNavigationProperties>, List<IpbWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<IpbWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<IpbWithNavigationProperties, IpbWithNavigationPropertiesDto>
                (await _ipbRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<IpbDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Ipb, IpbDto>(await _ipbRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetPartLookupAsync(LookupRequestDto input)
        {
            var query = (await _partRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.name != null &&
                         x.name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<AbpPoc.Parts.Part>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AbpPoc.Parts.Part>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(AbpPocPermissions.Ipbs.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _ipbRepository.DeleteAsync(id);
        }

        [Authorize(AbpPocPermissions.Ipbs.Create)]
        public virtual async Task<IpbDto> CreateAsync(IpbCreateDto input)
        {

            var ipb = await _ipbManager.CreateAsync(
            input.sourceId, input.relatedId, input.figureName, input.figureNumber, input.toNumber, input.indentureLevel
            );

            return ObjectMapper.Map<Ipb, IpbDto>(ipb);
        }

        [Authorize(AbpPocPermissions.Ipbs.Edit)]
        public virtual async Task<IpbDto> UpdateAsync(Guid id, IpbUpdateDto input)
        {

            var ipb = await _ipbManager.UpdateAsync(
            id,
            input.sourceId, input.relatedId, input.figureName, input.figureNumber, input.toNumber, input.indentureLevel, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Ipb, IpbDto>(ipb);
        }
    }
}