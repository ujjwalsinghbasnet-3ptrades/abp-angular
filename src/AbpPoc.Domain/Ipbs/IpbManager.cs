using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace AbpPoc.Ipbs
{
    public abstract class IpbManagerBase : DomainService
    {
        protected IIpbRepository _ipbRepository;

        public IpbManagerBase(IIpbRepository ipbRepository)
        {
            _ipbRepository = ipbRepository;
        }

        public virtual async Task<Ipb> CreateAsync(
        Guid? sourcePart, Guid? relatedPart, string ipbIndex, string figureName, string figureNumber, string sourceId, string relatedId, string? toNumber = null, string? indentureLevel = null)
        {
            Check.NotNullOrWhiteSpace(ipbIndex, nameof(ipbIndex));
            Check.Length(ipbIndex, nameof(ipbIndex), IpbConsts.ipbIndexMaxLength);
            Check.NotNullOrWhiteSpace(figureName, nameof(figureName));
            Check.Length(figureName, nameof(figureName), IpbConsts.figureNameMaxLength);
            Check.NotNullOrWhiteSpace(figureNumber, nameof(figureNumber));
            Check.Length(figureNumber, nameof(figureNumber), IpbConsts.figureNumberMaxLength);
            Check.NotNullOrWhiteSpace(sourceId, nameof(sourceId));
            Check.NotNullOrWhiteSpace(relatedId, nameof(relatedId));
            Check.Length(toNumber, nameof(toNumber), IpbConsts.toNumberMaxLength);
            Check.Length(indentureLevel, nameof(indentureLevel), IpbConsts.indentureLevelMaxLength);

            var ipb = new Ipb(
             GuidGenerator.Create(),
             sourcePart, relatedPart, ipbIndex, figureName, figureNumber, sourceId, relatedId, toNumber, indentureLevel
             );

            return await _ipbRepository.InsertAsync(ipb);
        }

        public virtual async Task<Ipb> UpdateAsync(
            Guid id,
            Guid? sourcePart, Guid? relatedPart, string ipbIndex, string figureName, string figureNumber, string sourceId, string relatedId, string? toNumber = null, string? indentureLevel = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(ipbIndex, nameof(ipbIndex));
            Check.Length(ipbIndex, nameof(ipbIndex), IpbConsts.ipbIndexMaxLength);
            Check.NotNullOrWhiteSpace(figureName, nameof(figureName));
            Check.Length(figureName, nameof(figureName), IpbConsts.figureNameMaxLength);
            Check.NotNullOrWhiteSpace(figureNumber, nameof(figureNumber));
            Check.Length(figureNumber, nameof(figureNumber), IpbConsts.figureNumberMaxLength);
            Check.NotNullOrWhiteSpace(sourceId, nameof(sourceId));
            Check.NotNullOrWhiteSpace(relatedId, nameof(relatedId));
            Check.Length(toNumber, nameof(toNumber), IpbConsts.toNumberMaxLength);
            Check.Length(indentureLevel, nameof(indentureLevel), IpbConsts.indentureLevelMaxLength);

            var ipb = await _ipbRepository.GetAsync(id);

            ipb.sourcePart = sourcePart;
            ipb.relatedPart = relatedPart;
            ipb.ipbIndex = ipbIndex;
            ipb.figureName = figureName;
            ipb.figureNumber = figureNumber;
            ipb.sourceId = sourceId;
            ipb.relatedId = relatedId;
            ipb.toNumber = toNumber;
            ipb.indentureLevel = indentureLevel;

            ipb.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _ipbRepository.UpdateAsync(ipb);
        }

    }
}