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

namespace AbpPoc.Documents
{
    public abstract class EfCoreDocumentRepositoryBase : EfCoreRepository<AbpPocDbContext, Document, Guid>
    {
        public EfCoreDocumentRepositoryBase(IDbContextProvider<AbpPocDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? name = null,
            int? sizeMin = null,
            int? sizeMax = null,
            string? type = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, name, sizeMin, sizeMax, type);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Document>> GetListAsync(
            string? filterText = null,
            string? name = null,
            int? sizeMin = null,
            int? sizeMax = null,
            string? type = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, sizeMin, sizeMax, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? DocumentConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            int? sizeMin = null,
            int? sizeMax = null,
            string? type = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, sizeMin, sizeMax, type);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Document> ApplyFilter(
            IQueryable<Document> query,
            string? filterText = null,
            string? name = null,
            int? sizeMin = null,
            int? sizeMax = null,
            string? type = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.name!.Contains(filterText!) || e.type!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.name.Contains(name))
                    .WhereIf(sizeMin.HasValue, e => e.size >= sizeMin!.Value)
                    .WhereIf(sizeMax.HasValue, e => e.size <= sizeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.type.Contains(type));
        }
    }
}