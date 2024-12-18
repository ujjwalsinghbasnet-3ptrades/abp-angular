using System;
using AbpPoc.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpPoc.Books;

public class BookAppService :
    CrudAppService<
        Book, //The Book entity
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {
        GetPolicyName = AbpPocPermissions.Books.Default;
        GetListPolicyName = AbpPocPermissions.Books.Default;
        CreatePolicyName = AbpPocPermissions.Books.Create;
        UpdatePolicyName = AbpPocPermissions.Books.Edit;
        DeletePolicyName = AbpPocPermissions.Books.Delete;
    }
}