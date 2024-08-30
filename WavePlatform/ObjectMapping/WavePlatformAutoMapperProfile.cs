using AutoMapper;
using WavePlatform.Entities.Books;
using WavePlatform.Services.Dtos.Books;

namespace WavePlatform.ObjectMapping;

public class WavePlatformAutoMapperProfile : Profile
{
    public WavePlatformAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<BookDto, CreateUpdateBookDto>();
        /* Create your AutoMapper object mappings here */
    }
}
