using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpPoc.PartTests
{
    public partial interface IPartTestRepository : IRepository<PartTest, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? partNumber = null,
            string? name = null,
            string? cageCode = null,
            string? distributionStatement = null,
            string? toNumber = null,
            string? smr = null,
            string? niin = null,
            string? fsc = null,
            string? wuc = null,
            string? uoc = null,
            string? uniqueId = null,
            string? nsn = null,
            string? imageUrl = null,
            CancellationToken cancellationToken = default);
        Task<List<PartTest>> GetListAsync(
                    string? filterText = null,
                    string? partNumber = null,
                    string? name = null,
                    string? cageCode = null,
                    string? distributionStatement = null,
                    string? toNumber = null,
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
            string? partNumber = null,
            string? name = null,
            string? cageCode = null,
            string? distributionStatement = null,
            string? toNumber = null,
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