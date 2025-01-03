using Volo.Abp.AutoMapper;
using AbpPoc.Ipbs;
using AbpPoc.Documents;
using System;
using AbpPoc.Shared;
using AbpPoc.Parts;
using AutoMapper;
using AbpPoc.Books;

namespace AbpPoc;

public class AbpPocApplicationAutoMapperProfile : Profile
{
    public AbpPocApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Part, PartDto>();
        CreateMap<Part, PartExcelDto>();

        CreateMap<Document, DocumentDto>();
        CreateMap<Document, DocumentExcelDto>();

        CreateMap<Part, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.name));
        CreateMap<Part, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.name));

        CreateMap<Ipb, IpbDto>();
        CreateMap<IpbWithNavigationProperties, IpbWithNavigationPropertiesDto>();
    }
}