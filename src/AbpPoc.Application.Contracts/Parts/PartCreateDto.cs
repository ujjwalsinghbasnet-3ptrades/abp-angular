using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AbpPoc.Parts
{
    public abstract class PartCreateDtoBase
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = PartConsts.nameMinLength)]
        public string name { get; set; } = null!;
        public string? description { get; set; }
        [Required]
        public string partNumber { get; set; } = null!;
        [Required]
        public string cageCode { get; set; } = null!;
        [Required]
        public string toNumber { get; set; } = null!;
        public string? distributionStatement { get; set; }
        public string? smr { get; set; }
        public string? niin { get; set; }
        public string? fsc { get; set; }
        public string? wuc { get; set; }
        public string? uoc { get; set; }
        public string? uniqueId { get; set; }
        [Required]
        public string nsn { get; set; } = null!;
        public string? imageUrl { get; set; }
    }
}