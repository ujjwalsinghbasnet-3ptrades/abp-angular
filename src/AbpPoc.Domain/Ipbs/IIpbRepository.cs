using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpPoc.Ipbs
{
    public partial interface IIpbRepository : IRepository<Ipb, Guid>
    {
        Task<IpbWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<IpbWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? ipbIndex = null,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null,
            string? sourceId = null,
            string? relatedId = null,
            Guid? sourcePart = null,
            Guid? relatedPart = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Ipb>> GetListAsync(
                    string? filterText = null,
                    string? ipbIndex = null,
                    string? figureName = null,
                    string? figureNumber = null,
                    string? toNumber = null,
                    string? indentureLevel = null,
                    string? sourceId = null,
                    string? relatedId = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? ipbIndex = null,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null,
            string? sourceId = null,
            string? relatedId = null,
            Guid? sourcePart = null,
            Guid? relatedPart = null,
            CancellationToken cancellationToken = default);
    }
}