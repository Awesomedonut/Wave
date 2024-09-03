using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WavePlatform.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using BookData;
using WavePlatform.Models;

namespace BookWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

      //  [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddToLibrary(Guid bookId)
        {
            // In a real app, you'd get the user ID from authentication
            var userId = Guid.NewGuid();

            var userLibrary = new UserLibrary
            {
                UserId = userId,
                BookId = bookId
            };

            _context.UserLibrary.Add(userLibrary);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MyLibrary()
        {
            // In a real app, you'd get the user ID from authentication
            var userId = Guid.NewGuid();

            var userBooks = await _context.UserLibrary
                .Where(ul => ul.UserId == userId)
              
       //         .ThenInclude(b => b.Author)
           //     .Select(ul => ul.Book)
                .ToListAsync();

            return View(userBooks);
        }
    }
}