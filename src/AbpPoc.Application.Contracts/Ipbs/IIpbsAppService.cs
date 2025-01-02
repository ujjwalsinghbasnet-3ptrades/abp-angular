using AbpPoc.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpPoc.Ipbs
{
    public partial interface IIpbsAppService : IApplicationService
    {

        Task<PagedResultDto<IpbWithNavigationPropertiesDto>> GetListAsync(GetIpbsInput input);

        Task<IpbWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<IpbDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPartLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<IpbDto> CreateAsync(IpbCreateDto input);

        Task<IpbDto> UpdateAsync(Guid id, IpbUpdateDto input);
    }
}