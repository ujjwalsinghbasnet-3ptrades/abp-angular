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
        public virtual string figureName { get; set; }

        [NotNull]
        public virtual string figureNumber { get; set; }

        [CanBeNull]
        public virtual string? toNumber { get; set; }

        [CanBeNull]
        public virtual string? indentureLevel { get; set; }
        public Guid? sourceId { get; set; }
        public Guid? relatedId { get; set; }

        protected IpbBase()
        {

        }

        public IpbBase(Guid id, Guid? sourceId, Guid? relatedId, string figureName, string figureNumber, string? toNumber = null, string? indentureLevel = null)
        {

            Id = id;
            Check.NotNull(figureName, nameof(figureName));
            Check.Length(figureName, nameof(figureName), IpbConsts.figureNameMaxLength, 0);
            Check.NotNull(figureNumber, nameof(figureNumber));
            Check.Length(figureNumber, nameof(figureNumber), IpbConsts.figureNumberMaxLength, 0);
            Check.Length(toNumber, nameof(toNumber), IpbConsts.toNumberMaxLength, 0);
            Check.Length(indentureLevel, nameof(indentureLevel), IpbConsts.indentureLevelMaxLength, 0);
            this.figureName = figureName;
            this.figureNumber = figureNumber;
            this.toNumber = toNumber;
            this.indentureLevel = indentureLevel;
            this.sourceId = sourceId;
            this.relatedId = relatedId;
        }

    }
}