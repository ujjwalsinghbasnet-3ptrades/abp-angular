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
                    sourcePart = dbContext.Set<Part>().FirstOrDefault(c => c.Id == ipb.sourcePart),
                    relatedPart = dbContext.Set<Part>().FirstOrDefault(c => c.Id == ipb.relatedPart)
                }).FirstOrDefault();
        }

        public virtual async Task<List<IpbWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, ipbIndex, figureName, figureNumber, toNumber, indentureLevel, sourceId, relatedId, sourcePart, relatedPart);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? IpbConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<IpbWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from ipb in (await GetDbSetAsync())
                   join sourcePart in (await GetDbContextAsync()).Set<Part>() on ipb.sourcePart equals sourcePart.Id into parts
                   from sourcePart in parts.DefaultIfEmpty()
                   join relatedPart in (await GetDbContextAsync()).Set<Part>() on ipb.relatedPart equals relatedPart.Id into parts1
                   from relatedPart in parts1.DefaultIfEmpty()
                   select new IpbWithNavigationProperties
                   {
                       Ipb = ipb,
                       sourcePart = sourcePart,
                       relatedPart = relatedPart
                   };
        }

        protected virtual IQueryable<IpbWithNavigationProperties> ApplyFilter(
            IQueryable<IpbWithNavigationProperties> query,
            string? filterText,
            string? ipbIndex = null,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null,
            string? sourceId = null,
            string? relatedId = null,
            Guid? sourcePart = null,
            Guid? relatedPart = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Ipb.ipbIndex!.Contains(filterText!) || e.Ipb.figureName!.Contains(filterText!) || e.Ipb.figureNumber!.Contains(filterText!) || e.Ipb.toNumber!.Contains(filterText!) || e.Ipb.indentureLevel!.Contains(filterText!) || e.Ipb.sourceId!.Contains(filterText!) || e.Ipb.relatedId!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(ipbIndex), e => e.Ipb.ipbIndex.Contains(ipbIndex))
                    .WhereIf(!string.IsNullOrWhiteSpace(figureName), e => e.Ipb.figureName.Contains(figureName))
                    .WhereIf(!string.IsNullOrWhiteSpace(figureNumber), e => e.Ipb.figureNumber.Contains(figureNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(toNumber), e => e.Ipb.toNumber.Contains(toNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(indentureLevel), e => e.Ipb.indentureLevel.Contains(indentureLevel))
                    .WhereIf(!string.IsNullOrWhiteSpace(sourceId), e => e.Ipb.sourceId.Contains(sourceId))
                    .WhereIf(!string.IsNullOrWhiteSpace(relatedId), e => e.Ipb.relatedId.Contains(relatedId))
                    .WhereIf(sourcePart != null && sourcePart != Guid.Empty, e => e.sourcePart != null && e.sourcePart.Id == sourcePart)
                    .WhereIf(relatedPart != null && relatedPart != Guid.Empty, e => e.relatedPart != null && e.relatedPart.Id == relatedPart);
        }

        public virtual async Task<List<Ipb>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, ipbIndex, figureName, figureNumber, toNumber, indentureLevel, sourceId, relatedId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? IpbConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, ipbIndex, figureName, figureNumber, toNumber, indentureLevel, sourceId, relatedId, sourcePart, relatedPart);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Ipb> ApplyFilter(
            IQueryable<Ipb> query,
            string? filterText = null,
            string? ipbIndex = null,
            string? figureName = null,
            string? figureNumber = null,
            string? toNumber = null,
            string? indentureLevel = null,
            string? sourceId = null,
            string? relatedId = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ipbIndex!.Contains(filterText!) || e.figureName!.Contains(filterText!) || e.figureNumber!.Contains(filterText!) || e.toNumber!.Contains(filterText!) || e.indentureLevel!.Contains(filterText!) || e.sourceId!.Contains(filterText!) || e.relatedId!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(ipbIndex), e => e.ipbIndex.Contains(ipbIndex))
                    .WhereIf(!string.IsNullOrWhiteSpace(figureName), e => e.figureName.Contains(figureName))
                    .WhereIf(!string.IsNullOrWhiteSpace(figureNumber), e => e.figureNumber.Contains(figureNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(toNumber), e => e.toNumber.Contains(toNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(indentureLevel), e => e.indentureLevel.Contains(indentureLevel))
                    .WhereIf(!string.IsNullOrWhiteSpace(sourceId), e => e.sourceId.Contains(sourceId))
                    .WhereIf(!string.IsNullOrWhiteSpace(relatedId), e => e.relatedId.Contains(relatedId));
        }
    }
}