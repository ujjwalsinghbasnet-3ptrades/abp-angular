using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AbpPoc.Documents
{
    public abstract class DocumentCreateDtoBase
    {
        [Required]
        public string name { get; set; } = null!;
        public int size { get; set; }
        public string? type { get; set; }
    }
}