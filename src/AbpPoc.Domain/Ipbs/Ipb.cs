using AbpPoc.Parts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AbpPoc.Ipbs
{
    public abstract class IpbBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string ipbIndex { get; set; }

        [NotNull]
        public virtual string figureName { get; set; }

        [NotNull]
        public virtual string figureNumber { get; set; }

        [CanBeNull]
        public virtual string? toNumber { get; set; }

        [CanBeNull]
        public virtual string? indentureLevel { get; set; }

        [NotNull]
        public virtual string sourceId { get; set; }

        [NotNull]
        public virtual string relatedId { get; set; }
        public Guid? sourcePart { get; set; }
        public Guid? relatedPart { get; set; }

        protected IpbBase()
        {

        }

        public IpbBase(Guid id, Guid? sourcePart, Guid? relatedPart, string ipbIndex, string figureName, string figureNumber, string sourceId, string relatedId, string? toNumber = null, string? indentureLevel = null)
        {

            Id = id;
            Check.NotNull(ipbIndex, nameof(ipbIndex));
            Check.Length(ipbIndex, nameof(ipbIndex), IpbConsts.ipbIndexMaxLength, 0);
            Check.NotNull(figureName, nameof(figureName));
            Check.Length(figureName, nameof(figureName), IpbConsts.figureNameMaxLength, 0);
            Check.NotNull(figureNumber, nameof(figureNumber));
            Check.Length(figureNumber, nameof(figureNumber), IpbConsts.figureNumberMaxLength, 0);
            Check.NotNull(sourceId, nameof(sourceId));
            Check.NotNull(relatedId, nameof(relatedId));
            Check.Length(toNumber, nameof(toNumber), IpbConsts.toNumberMaxLength, 0);
            Check.Length(indentureLevel, nameof(indentureLevel), IpbConsts.indentureLevelMaxLength, 0);
            this.ipbIndex = ipbIndex;
            this.figureName = figureName;
            this.figureNumber = figureNumber;
            this.sourceId = sourceId;
            this.relatedId = relatedId;
            this.toNumber = toNumber;
            this.indentureLevel = indentureLevel;
            this.sourcePart = sourcePart;
            this.relatedPart = relatedPart;
        }

    }
}