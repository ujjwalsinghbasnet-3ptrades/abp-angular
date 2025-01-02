using AbpPoc.Shared;
using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AbpPoc.Ipbs;

namespace AbpPoc.Controllers.Ipbs
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Ipb")]
    [Route("api/app/ipbs")]

    public abstract class IpbControllerBase : AbpController
    {
        protected IIpbsAppService _ipbsAppService;

        public IpbControllerBase(IIpbsAppService ipbsAppService)
        {
            _ipbsAppService = ipbsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<IpbWithNavigationPropertiesDto>> GetListAsync(GetIpbsInput input)
        {
            return _ipbsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<IpbWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _ipbsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<IpbDto> GetAsync(Guid id)
        {
            return _ipbsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("part-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetPartLookupAsync(LookupRequestDto input)
        {
            return _ipbsAppService.GetPartLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<IpbDto> CreateAsync(IpbCreateDto input)
        {
            return _ipbsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<IpbDto> UpdateAsync(Guid id, IpbUpdateDto input)
        {
            return _ipbsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _ipbsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("source-part/{sourcePartId}")]
        public Task<PagedResultDto<IpbWithNavigationPropertiesDto>> GetIpbForSourcePart(string sourcePartId)
        {
            return _ipbsAppService.GetListAsync(new GetIpbsInput { sourceId = sourcePartId });
        }
    }
}