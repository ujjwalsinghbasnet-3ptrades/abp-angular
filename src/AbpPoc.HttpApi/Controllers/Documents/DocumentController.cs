using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AbpPoc.Documents;
using Volo.Abp.Content;
using AbpPoc.Shared;

namespace AbpPoc.Controllers.Documents
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Document")]
    [Route("api/app/documents")]

    public abstract class DocumentControllerBase : AbpController
    {
        protected IDocumentsAppService _documentsAppService;

        public DocumentControllerBase(IDocumentsAppService documentsAppService)
        {
            _documentsAppService = documentsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<DocumentDto>> GetListAsync(GetDocumentsInput input)
        {
            return _documentsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<DocumentDto> GetAsync(Guid id)
        {
            return _documentsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<DocumentDto> CreateAsync(DocumentCreateDto input)
        {
            return _documentsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DocumentDto> UpdateAsync(Guid id, DocumentUpdateDto input)
        {
            return _documentsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _documentsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(DocumentExcelDownloadDto input)
        {
            return _documentsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<AbpPoc.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _documentsAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> documentIds)
        {
            return _documentsAppService.DeleteByIdsAsync(documentIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetDocumentsInput input)
        {
            return _documentsAppService.DeleteAllAsync(input);
        }
    }
}