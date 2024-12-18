using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using AbpPoc.Shared;

namespace AbpPoc.PartTests
{
    public partial interface IPartTestsAppService : IApplicationService
    {

        Task<PagedResultDto<PartTestDto>> GetListAsync(GetPartTestsInput input);

        Task<PartTestDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<PartTestDto> CreateAsync(PartTestCreateDto input);

        Task<PartTestDto> UpdateAsync(Guid id, PartTestUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PartTestExcelDownloadDto input);
        Task DeleteByIdsAsync(List<Guid> parttestIds);

        Task DeleteAllAsync(GetPartTestsInput input);
        Task<AbpPoc.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}