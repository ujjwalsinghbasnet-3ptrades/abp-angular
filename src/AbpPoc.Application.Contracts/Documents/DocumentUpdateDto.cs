using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AbpPoc.Documents
{
    public abstract class DocumentUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        public string name { get; set; } = null!;
        public int size { get; set; }
        public string? type { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}