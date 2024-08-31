using BookData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WavePlatform.Models;

namespace WavePlatform.Views.Books
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book FirstBook { get; set; }


        public async Task OnGetAsync()
        {
            // Fetch books from the database, including their associated authors
            FirstBook = await _context.Books.FirstAsync();
        }

    }
}
