using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AbpPoc.Ipbs
{
    public abstract class IpbCreateDtoBase
    {
        [Required]
        [StringLength(IpbConsts.ipbIndexMaxLength)]
        public string ipbIndex { get; set; } = null!;
        [Required]
        [StringLength(IpbConsts.figureNameMaxLength)]
        public string figureName { get; set; } = null!;
        [Required]
        [StringLength(IpbConsts.figureNumberMaxLength)]
        public string figureNumber { get; set; } = null!;
        [StringLength(IpbConsts.toNumberMaxLength)]
        public string? toNumber { get; set; }
        [StringLength(IpbConsts.indentureLevelMaxLength)]
        public string? indentureLevel { get; set; }
        [Required]
        public string sourceId { get; set; } = null!;
        [Required]
        public string relatedId { get; set; } = null!;
        public Guid? sourcePart { get; set; }
        public Guid? relatedPart { get; set; }
    }
}