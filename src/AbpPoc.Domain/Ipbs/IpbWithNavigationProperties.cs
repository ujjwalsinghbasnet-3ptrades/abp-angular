using AbpPoc.Parts;

namespace AbpPoc.Ipbs
{
    public abstract class IpbWithNavigationPropertiesBase
    {
        public Ipb Ipb { get; set; } = null!;

        public Part source { get; set; } = null!;
        public Part related { get; set; } = null!;
        

        
    }
}