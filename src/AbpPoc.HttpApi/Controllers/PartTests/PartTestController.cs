using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AbpPoc.PartTests;
using Volo.Abp.Content;
using AbpPoc.Shared;

namespace AbpPoc.Controllers.PartTests
{
    [RemoteService]
    [Area("app")]
    [ControllerName("PartTest")]
    [Route("api/app/part-tests")]

    public abstract class PartTestControllerBase : AbpController
    {
        protected IPartTestsAppService _partTestsAppService;

        public PartTestControllerBase(IPartTestsAppService partTestsAppService)
        {
            _partTestsAppService = partTestsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<PartTestDto>> GetListAsync(GetPartTestsInput input)
        {
            return _partTestsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PartTestDto> GetAsync(Guid id)
        {
            return _partTestsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<PartTestDto> CreateAsync(PartTestCreateDto input)
        {
            return _partTestsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PartTestDto> UpdateAsync(Guid id, PartTestUpdateDto input)
        {
            return _partTestsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _partTestsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(PartTestExcelDownloadDto input)
        {
            return _partTestsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<AbpPoc.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _partTestsAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> parttestIds)
        {
            return _partTestsAppService.DeleteByIdsAsync(parttestIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetPartTestsInput input)
        {
            return _partTestsAppService.DeleteAllAsync(input);
        }
    }
}