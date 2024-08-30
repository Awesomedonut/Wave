namespace WavePlatform.Models
{
    public class BookRating
    {
        public short Score { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}



