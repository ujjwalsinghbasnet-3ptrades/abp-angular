using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpPoc.Parts
{
    public partial interface IPartRepository : IRepository<Part, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? name = null,
            string? description = null,
            string? partNumber = null,
            string? cageCode = null,
            string? toNumber = null,
            string? distributionStatement = null,
            string? smr = null,
            string? niin = null,
            string? fsc = null,
            string? wuc = null,
            string? uoc = null,
            string? uniqueId = null,
            string? nsn = null,
            string? imageUrl = null,
            CancellationToken cancellationToken = default);
        Task<List<Part>> GetListAsync(
                    string? filterText = null,
                    string? name = null,
                    string? description = null,
                    string? partNumber = null,
                    string? cageCode = null,
                    string? toNumber = null,
                    string? distributionStatement = null,
                    string? smr = null,
                    string? niin = null,
                    string? fsc = null,
                    string? wuc = null,
                    string? uoc = null,
                    string? uniqueId = null,
                    string? nsn = null,
                    string? imageUrl = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? description = null,
            string? partNumber = null,
            string? cageCode = null,
            string? toNumber = null,
            string? distributionStatement = null,
            string? smr = null,
            string? niin = null,
            string? fsc = null,
            string? wuc = null,
            string? uoc = null,
            string? uniqueId = null,
            string? nsn = null,
            string? imageUrl = null,
            CancellationToken cancellationToken = default);
    }
}