using System;

namespace AbpPoc.Parts
{
    public abstract class PartExcelDtoBase
    {
        public string name { get; set; } = null!;
        public string? description { get; set; }
        public string partNumber { get; set; } = null!;
        public string cageCode { get; set; } = null!;
        public string toNumber { get; set; } = null!;
        public string? distributionStatement { get; set; }
        public string? smr { get; set; }
        public string? niin { get; set; }
        public string? fsc { get; set; }
        public string? wuc { get; set; }
        public string? uoc { get; set; }
        public string? uniqueId { get; set; }
        public string nsn { get; set; } = null!;
        public string? imageUrl { get; set; }
    }
}