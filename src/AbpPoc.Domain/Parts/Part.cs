using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AbpPoc.Parts
{
    public abstract class PartBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string name { get; set; }

        [CanBeNull]
        public virtual string? description { get; set; }

        [NotNull]
        public virtual string partNumber { get; set; }

        [NotNull]
        public virtual string cageCode { get; set; }

        [NotNull]
        public virtual string toNumber { get; set; }

        [CanBeNull]
        public virtual string? distributionStatement { get; set; }

        [CanBeNull]
        public virtual string? smr { get; set; }

        [CanBeNull]
        public virtual string? niin { get; set; }

        [CanBeNull]
        public virtual string? fsc { get; set; }

        [CanBeNull]
        public virtual string? wuc { get; set; }

        [CanBeNull]
        public virtual string? uoc { get; set; }

        [CanBeNull]
        public virtual string? uniqueId { get; set; }

        [NotNull]
        public virtual string nsn { get; set; }

        [CanBeNull]
        public virtual string? imageUrl { get; set; }

        protected PartBase()
        {

        }

        public PartBase(Guid id, string name, string partNumber, string cageCode, string toNumber, string nsn, string? description = null, string? distributionStatement = null, string? smr = null, string? niin = null, string? fsc = null, string? wuc = null, string? uoc = null, string? uniqueId = null, string? imageUrl = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.NotNull(partNumber, nameof(partNumber));
            Check.NotNull(cageCode, nameof(cageCode));
            Check.NotNull(toNumber, nameof(toNumber));
            Check.NotNull(nsn, nameof(nsn));
            this.name = name;
            this.partNumber = partNumber;
            this.cageCode = cageCode;
            this.toNumber = toNumber;
            this.nsn = nsn;
            this.description = description;
            this.distributionStatement = distributionStatement;
            this.smr = smr;
            this.niin = niin;
            this.fsc = fsc;
            this.wuc = wuc;
            this.uoc = uoc;
            this.uniqueId = uniqueId;
            this.imageUrl = imageUrl;
        }

    }
}