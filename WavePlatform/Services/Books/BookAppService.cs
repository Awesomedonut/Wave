using System;
using WavePlatform.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using WavePlatform.Services.Dtos.Books;
using WavePlatform.Entities.Books;

namespace WavePlatform.Services.Books;

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
        GetPolicyName = WavePlatformPermissions.Books.Default;
        GetListPolicyName = WavePlatformPermissions.Books.Default;
        CreatePolicyName = WavePlatformPermissions.Books.Create;
        UpdatePolicyName = WavePlatformPermissions.Books.Edit;
        DeletePolicyName = WavePlatformPermissions.Books.Delete;
    }
}