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
        Guid? sourceId, Guid? relatedId, string figureName, string figureNumber, string? toNumber = null, string? indentureLevel = null)
        {
            Check.NotNullOrWhiteSpace(figureName, nameof(figureName));
            Check.Length(figureName, nameof(figureName), IpbConsts.figureNameMaxLength);
            Check.NotNullOrWhiteSpace(figureNumber, nameof(figureNumber));
            Check.Length(figureNumber, nameof(figureNumber), IpbConsts.figureNumberMaxLength);
            Check.Length(toNumber, nameof(toNumber), IpbConsts.toNumberMaxLength);
            Check.Length(indentureLevel, nameof(indentureLevel), IpbConsts.indentureLevelMaxLength);

            var ipb = new Ipb(
             GuidGenerator.Create(),
             sourceId, relatedId, figureName, figureNumber, toNumber, indentureLevel
             );

            return await _ipbRepository.InsertAsync(ipb);
        }

        public virtual async Task<Ipb> UpdateAsync(
            Guid id,
            Guid? sourceId, Guid? relatedId, string figureName, string figureNumber, string? toNumber = null, string? indentureLevel = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(figureName, nameof(figureName));
            Check.Length(figureName, nameof(figureName), IpbConsts.figureNameMaxLength);
            Check.NotNullOrWhiteSpace(figureNumber, nameof(figureNumber));
            Check.Length(figureNumber, nameof(figureNumber), IpbConsts.figureNumberMaxLength);
            Check.Length(toNumber, nameof(toNumber), IpbConsts.toNumberMaxLength);
            Check.Length(indentureLevel, nameof(indentureLevel), IpbConsts.indentureLevelMaxLength);

            var ipb = await _ipbRepository.GetAsync(id);

            ipb.sourceId = sourceId;
            ipb.relatedId = relatedId;
            ipb.figureName = figureName;
            ipb.figureNumber = figureNumber;
            ipb.toNumber = toNumber;
            ipb.indentureLevel = indentureLevel;

            ipb.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _ipbRepository.UpdateAsync(ipb);
        }

    }
}