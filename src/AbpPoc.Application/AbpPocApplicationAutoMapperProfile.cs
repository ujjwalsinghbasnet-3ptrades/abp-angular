using AbpPoc.PartTests;
using System;
using AbpPoc.Shared;
using Volo.Abp.AutoMapper;
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

        CreateMap<PartTest, PartTestDto>();
        CreateMap<PartTest, PartTestExcelDto>();
    }
}