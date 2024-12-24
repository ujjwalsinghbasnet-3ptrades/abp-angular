using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace AbpPoc.Documents
{
    public abstract class DocumentDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string name { get; set; } = null!;
        public int size { get; set; }
        public string? type { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}