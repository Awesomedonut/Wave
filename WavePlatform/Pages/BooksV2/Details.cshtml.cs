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

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            if(Book.AuthorId != null)
            {
                Book.AuthorName = (await _context.Authors.FirstOrDefaultAsync(m => m.AuthorId == Book.AuthorId)).Name;
            }
            return Page();
        }
    }
}