using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace AbpPoc.Ipbs
{
    public abstract class IpbDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string ipbIndex { get; set; } = null!;
        public string figureName { get; set; } = null!;
        public string figureNumber { get; set; } = null!;
        public string? toNumber { get; set; }
        public string? indentureLevel { get; set; }
        public string sourceId { get; set; } = null!;
        public string relatedId { get; set; } = null!;
        public Guid? sourcePart { get; set; }
        public Guid? relatedPart { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}