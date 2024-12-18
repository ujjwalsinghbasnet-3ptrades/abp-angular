using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AbpPoc.PartTests
{
    public abstract class PartTestCreateDtoBase
    {
        [Required]
        public string partNumber { get; set; } = null!;
        [Required]
        public string name { get; set; } = null!;
        [Required]
        public string cageCode { get; set; } = null!;
        [Required]
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
    }
}