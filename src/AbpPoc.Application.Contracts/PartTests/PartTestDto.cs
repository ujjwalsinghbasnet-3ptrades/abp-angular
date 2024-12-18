using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace AbpPoc.PartTests
{
    public abstract class PartTestDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string partNumber { get; set; } = null!;
        public string name { get; set; } = null!;
        public string cageCode { get; set; } = null!;
        public string distributionStatement { get; set; } = null!;
        public string? toNumber { get; set; }
        public string? smr { get; set; }
        public string? niin { get; set; }
        public string? fsc { get; set; }
        public string? wuc { get; set; }
        public string? uoc { get; set; }
        public string? uniqueId { get; set; }
        public string? nsn { get; set; }
        public string? imageUrl { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}