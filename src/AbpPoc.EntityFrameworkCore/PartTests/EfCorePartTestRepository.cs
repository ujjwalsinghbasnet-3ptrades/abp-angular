using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using AbpPoc.EntityFrameworkCore;

namespace AbpPoc.PartTests
{
    public abstract class EfCorePartTestRepositoryBase : EfCoreRepository<AbpPocDbContext, PartTest, Guid>
    {
        public EfCorePartTestRepositoryBase(IDbContextProvider<AbpPocDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
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
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, partNumber, name, cageCode, distributionStatement, toNumber, smr, niin, fsc, wuc, uoc, uniqueId, nsn, imageUrl);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<PartTest>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, partNumber, name, cageCode, distributionStatement, toNumber, smr, niin, fsc, wuc, uoc, uniqueId, nsn, imageUrl);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PartTestConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, partNumber, name, cageCode, distributionStatement, toNumber, smr, niin, fsc, wuc, uoc, uniqueId, nsn, imageUrl);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<PartTest> ApplyFilter(
            IQueryable<PartTest> query,
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
            string? imageUrl = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.partNumber!.Contains(filterText!) || e.name!.Contains(filterText!) || e.cageCode!.Contains(filterText!) || e.distributionStatement!.Contains(filterText!) || e.toNumber!.Contains(filterText!) || e.smr!.Contains(filterText!) || e.niin!.Contains(filterText!) || e.fsc!.Contains(filterText!) || e.wuc!.Contains(filterText!) || e.uoc!.Contains(filterText!) || e.uniqueId!.Contains(filterText!) || e.nsn!.Contains(filterText!) || e.imageUrl!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(partNumber), e => e.partNumber.Contains(partNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(cageCode), e => e.cageCode.Contains(cageCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(distributionStatement), e => e.distributionStatement.Contains(distributionStatement))
                    .WhereIf(!string.IsNullOrWhiteSpace(toNumber), e => e.toNumber.Contains(toNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(smr), e => e.smr.Contains(smr))
                    .WhereIf(!string.IsNullOrWhiteSpace(niin), e => e.niin.Contains(niin))
                    .WhereIf(!string.IsNullOrWhiteSpace(fsc), e => e.fsc.Contains(fsc))
                    .WhereIf(!string.IsNullOrWhiteSpace(wuc), e => e.wuc.Contains(wuc))
                    .WhereIf(!string.IsNullOrWhiteSpace(uoc), e => e.uoc.Contains(uoc))
                    .WhereIf(!string.IsNullOrWhiteSpace(uniqueId), e => e.uniqueId.Contains(uniqueId))
                    .WhereIf(!string.IsNullOrWhiteSpace(nsn), e => e.nsn.Contains(nsn))
                    .WhereIf(!string.IsNullOrWhiteSpace(imageUrl), e => e.imageUrl.Contains(imageUrl));
        }
    }
}