using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WavePlatform.Models
{

    public class Book
    {
        public Guid BookId { get; set; }
        public Guid? AuthorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public byte[]? CoverImage { get; set; }

        [NotMapped]
       public string? AuthorName { get; set; }
    }
}



