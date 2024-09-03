// Data Access
using Microsoft.EntityFrameworkCore;
//using BookWebApp.Models;
using WavePlatform.Models;

namespace BookData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }
        public DbSet<UserLibrary> UserLibrary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookRating>()
                .HasKey(br => new { br.UserId, br.BookId });

            modelBuilder.Entity<UserLibrary>()
                .HasKey(ul => new { ul.UserId, ul.BookId });
        }
    }
}
