using Volo.Abp.Application.Dtos;
using System;

namespace AbpPoc.Ipbs
{
    public abstract class GetIpbsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? figureName { get; set; }
        public string? figureNumber { get; set; }
        public string? toNumber { get; set; }
        public string? indentureLevel { get; set; }
        public Guid? sourceId { get; set; }
        public Guid? relatedId { get; set; }

        public GetIpbsInputBase()
        {

        }
    }
}