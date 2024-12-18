using Volo.Abp.Application.Dtos;
using System;

namespace AbpPoc.PartTests
{
    public abstract class GetPartTestsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? partNumber { get; set; }
        public string? name { get; set; }
        public string? cageCode { get; set; }
        public string? distributionStatement { get; set; }
        public string? toNumber { get; set; }
        public string? smr { get; set; }
        public string? niin { get; set; }
        public string? fsc { get; set; }
        public string? wuc { get; set; }
        public string? uoc { get; set; }
        public string? uniqueId { get; set; }
        public string? nsn { get; set; }
        public string? imageUrl { get; set; }

        public GetPartTestsInputBase()
        {

        }
    }
}