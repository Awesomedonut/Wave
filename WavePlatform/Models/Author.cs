using System.ComponentModel.DataAnnotations;

namespace WavePlatform.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}



