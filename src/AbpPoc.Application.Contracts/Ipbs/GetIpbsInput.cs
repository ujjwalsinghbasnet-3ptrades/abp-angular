using Volo.Abp.Application.Dtos;
using System;

namespace AbpPoc.Ipbs
{
    public abstract class GetIpbsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? ipbIndex { get; set; }
        public string? figureName { get; set; }
        public string? figureNumber { get; set; }
        public string? toNumber { get; set; }
        public string? indentureLevel { get; set; }
        public string? sourceId { get; set; }
        public string? relatedId { get; set; }
        public Guid? sourcePart { get; set; }
        public Guid? relatedPart { get; set; }

        public GetIpbsInputBase()
        {

        }
    }
}