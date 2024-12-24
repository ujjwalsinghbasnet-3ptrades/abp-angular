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
using AbpPoc.Documents;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using AbpPoc.Shared;

namespace AbpPoc.Documents
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AbpPocPermissions.Documents.Default)]
    public abstract class DocumentsAppServiceBase : AbpPocAppService
    {
        protected IDistributedCache<DocumentDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IDocumentRepository _documentRepository;
        protected DocumentManager _documentManager;

        public DocumentsAppServiceBase(IDocumentRepository documentRepository, DocumentManager documentManager, IDistributedCache<DocumentDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _documentRepository = documentRepository;
            _documentManager = documentManager;

        }

        public virtual async Task<PagedResultDto<DocumentDto>> GetListAsync(GetDocumentsInput input)
        {
            var totalCount = await _documentRepository.GetCountAsync(input.FilterText, input.name, input.sizeMin, input.sizeMax, input.type);
            var items = await _documentRepository.GetListAsync(input.FilterText, input.name, input.sizeMin, input.sizeMax, input.type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<DocumentDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Document>, List<DocumentDto>>(items)
            };
        }

        public virtual async Task<DocumentDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Document, DocumentDto>(await _documentRepository.GetAsync(id));
        }

        [Authorize(AbpPocPermissions.Documents.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _documentRepository.DeleteAsync(id);
        }

        [Authorize(AbpPocPermissions.Documents.Create)]
        public virtual async Task<DocumentDto> CreateAsync(DocumentCreateDto input)
        {

            var document = await _documentManager.CreateAsync(
            input.name, input.size, input.type
            );

            return ObjectMapper.Map<Document, DocumentDto>(document);
        }

        [Authorize(AbpPocPermissions.Documents.Edit)]
        public virtual async Task<DocumentDto> UpdateAsync(Guid id, DocumentUpdateDto input)
        {

            var document = await _documentManager.UpdateAsync(
            id,
            input.name, input.size, input.type, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Document, DocumentDto>(document);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(DocumentExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _documentRepository.GetListAsync(input.FilterText, input.name, input.sizeMin, input.sizeMax, input.type);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Document>, List<DocumentExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Documents.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(AbpPocPermissions.Documents.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> documentIds)
        {
            await _documentRepository.DeleteManyAsync(documentIds);
        }

        [Authorize(AbpPocPermissions.Documents.Delete)]
        public virtual async Task DeleteAllAsync(GetDocumentsInput input)
        {
            await _documentRepository.DeleteAllAsync(input.FilterText, input.name, input.sizeMin, input.sizeMax, input.type);
        }
        public virtual async Task<AbpPoc.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new DocumentDownloadTokenCacheItem { Token = token },
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