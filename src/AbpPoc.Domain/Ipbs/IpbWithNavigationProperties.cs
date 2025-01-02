using AbpPoc.Parts;
using AbpPoc.Parts;

using System;
using System.Collections.Generic;

namespace AbpPoc.Ipbs
{
    public abstract class IpbWithNavigationPropertiesBase
    {
        public Ipb Ipb { get; set; } = null!;

        public Part sourcePart { get; set; } = null!;
        public Part relatedPart { get; set; } = null!;
        

        
    }
}