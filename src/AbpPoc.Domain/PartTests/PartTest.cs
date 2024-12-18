using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AbpPoc.PartTests
{
    public abstract class PartTestBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string partNumber { get; set; }

        [NotNull]
        public virtual string name { get; set; }

        [NotNull]
        public virtual string cageCode { get; set; }

        [NotNull]
        public virtual string distributionStatement { get; set; }

        [CanBeNull]
        public virtual string? toNumber { get; set; }

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

        [CanBeNull]
        public virtual string? nsn { get; set; }

        [CanBeNull]
        public virtual string? imageUrl { get; set; }

        protected PartTestBase()
        {

        }

        public PartTestBase(Guid id, string partNumber, string name, string cageCode, string distributionStatement, string? toNumber = null, string? smr = null, string? niin = null, string? fsc = null, string? wuc = null, string? uoc = null, string? uniqueId = null, string? nsn = null, string? imageUrl = null)
        {

            Id = id;
            Check.NotNull(partNumber, nameof(partNumber));
            Check.NotNull(name, nameof(name));
            Check.NotNull(cageCode, nameof(cageCode));
            Check.NotNull(distributionStatement, nameof(distributionStatement));
            this.partNumber = partNumber;
            this.name = name;
            this.cageCode = cageCode;
            this.distributionStatement = distributionStatement;
            this.toNumber = toNumber;
            this.smr = smr;
            this.niin = niin;
            this.fsc = fsc;
            this.wuc = wuc;
            this.uoc = uoc;
            this.uniqueId = uniqueId;
            this.nsn = nsn;
            this.imageUrl = imageUrl;
        }

    }
}