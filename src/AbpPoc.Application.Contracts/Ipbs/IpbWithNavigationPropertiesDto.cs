using AbpPoc.Parts;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace AbpPoc.Ipbs
{
    public abstract class IpbWithNavigationPropertiesDtoBase
    {
        public IpbDto Ipb { get; set; } = null!;

        public PartDto sourcePart { get; set; } = null!;
        public PartDto relatedPart { get; set; } = null!;

    }
}