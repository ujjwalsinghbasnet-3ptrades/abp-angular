using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AbpPoc.Documents
{
    public abstract class DocumentBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string name { get; set; }

        public virtual int size { get; set; }

        [CanBeNull]
        public virtual string? type { get; set; }

        protected DocumentBase()
        {

        }

        public DocumentBase(Guid id, string name, int size, string? type = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            this.name = name;
            this.size = size;
            this.type = type;
        }

    }
}