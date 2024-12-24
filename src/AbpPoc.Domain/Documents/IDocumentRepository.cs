using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpPoc.Documents
{
    public partial interface IDocumentRepository : IRepository<Document, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? name = null,
            int? sizeMin = null,
            int? sizeMax = null,
            string? type = null,
            CancellationToken cancellationToken = default);
        Task<List<Document>> GetListAsync(
                    string? filterText = null,
                    string? name = null,
                    int? sizeMin = null,
                    int? sizeMax = null,
                    string? type = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            int? sizeMin = null,
            int? sizeMax = null,
            string? type = null,
            CancellationToken cancellationToken = default);
    }
}