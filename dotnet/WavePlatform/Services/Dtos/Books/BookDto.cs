using System;
using Volo.Abp.Application.Dtos;
using WavePlatform.Entities.Books;

namespace WavePlatform.Services.Dtos.Books;

public class BookDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }
}