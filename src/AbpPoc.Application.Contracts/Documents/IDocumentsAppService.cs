using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using AbpPoc.Shared;

namespace AbpPoc.Documents
{
    public partial interface IDocumentsAppService : IApplicationService
    {

        Task<PagedResultDto<DocumentDto>> GetListAsync(GetDocumentsInput input);

        Task<DocumentDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<DocumentDto> CreateAsync(DocumentCreateDto input);

        Task<DocumentDto> UpdateAsync(Guid id, DocumentUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(DocumentExcelDownloadDto input);
        Task DeleteByIdsAsync(List<Guid> documentIds);

        Task DeleteAllAsync(GetDocumentsInput input);
        Task<AbpPoc.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}