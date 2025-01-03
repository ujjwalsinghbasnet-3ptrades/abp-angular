using AbpPoc.Parts;
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

namespace AbpPoc.Ipbs
{
    public abstract class EfCoreIpbRepositoryBase : EfCoreRepository<AbpPocDbContext, Ipb, Guid>
    {
        public EfCoreIpbRepositoryBase(IDbContextProvider<AbpPocDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<IpbWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id)
                .Select(ipb => new IpbWithNavigationProperties
                {
                    Ipb = ipb,
                    source = dbContext.Set<Part>().FirstOrDefault(c => c.Id == ipb.sourceId),
                    related = dbContext.Set<Part>().FirstOrDefault(c => c.Id == ipb.relatedId)
                }).FirstOrDefault();
        }

        public virtual async Task<List<IpbWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null,
            Guid? sourceId = null,
            Guid? relatedId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            Console.WriteLine("query: " + query);
            query = ApplyFilter(query, filterText, figureName, figureNumber, toNumber, indentureLevel, sourceId, relatedId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? IpbConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<IpbWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from ipb in (await GetDbSetAsync())
                   join source in (await GetDbContextAsync()).Set<Part>() on ipb.sourceId equals source.Id into parts
                   from source in parts.DefaultIfEmpty()
                   join related in (await GetDbContextAsync()).Set<Part>() on ipb.relatedId equals related.Id into parts1
                   from related in parts1.DefaultIfEmpty()
                   select new IpbWithNavigationProperties
                   {
                       Ipb = ipb,
                       source = source,
                       related = related
                   };
        }

        protected virtual IQueryable<IpbWithNavigationProperties> ApplyFilter(
            IQueryable<IpbWithNavigationProperties> query,
            string? filterText,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null,
            Guid? sourceId = null,
            Guid? relatedId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Ipb.figureName!.Contains(filterText!) || e.Ipb.figureNumber!.Contains(filterText!) || e.Ipb.toNumber!.Contains(filterText!) || e.Ipb.indentureLevel!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(figureName), e => e.Ipb.figureName.Contains(figureName))
                    .WhereIf(!string.IsNullOrWhiteSpace(figureNumber), e => e.Ipb.figureNumber.Contains(figureNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(toNumber), e => e.Ipb.toNumber.Contains(toNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(indentureLevel), e => e.Ipb.indentureLevel.Contains(indentureLevel))
                    .WhereIf(sourceId != null && sourceId != Guid.Empty, e => e.source != null && e.source.Id == sourceId)
                    .WhereIf(relatedId != null && relatedId != Guid.Empty, e => e.related != null && e.related.Id == relatedId);
        }

        public virtual async Task<List<Ipb>> GetListAsync(
            string? filterText = null,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, figureName, figureNumber, toNumber, indentureLevel);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? IpbConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null,
            Guid? sourceId = null,
            Guid? relatedId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, figureName, figureNumber, toNumber, indentureLevel, sourceId, relatedId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Ipb> ApplyFilter(
            IQueryable<Ipb> query,
            string? filterText = null,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.figureName!.Contains(filterText!) || e.figureNumber!.Contains(filterText!) || e.toNumber!.Contains(filterText!) || e.indentureLevel!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(figureName), e => e.figureName.Contains(figureName))
                    .WhereIf(!string.IsNullOrWhiteSpace(figureNumber), e => e.figureNumber.Contains(figureNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(toNumber), e => e.toNumber.Contains(toNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(indentureLevel), e => e.indentureLevel.Contains(indentureLevel));
        }
    }
}