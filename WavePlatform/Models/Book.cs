using System.ComponentModel.DataAnnotations;
using System;

namespace WavePlatform.Models
{

    public class Book
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? CoverImage { get; set; }
        public Author? Author { get; set; }
    }
}



