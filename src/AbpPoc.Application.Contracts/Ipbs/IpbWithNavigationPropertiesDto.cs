using AbpPoc.Parts;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace AbpPoc.Ipbs
{
    public abstract class IpbWithNavigationPropertiesDtoBase
    {
        public IpbDto Ipb { get; set; } = null!;

        public PartDto source { get; set; } = null!;
        public PartDto related { get; set; } = null!;

    }
}