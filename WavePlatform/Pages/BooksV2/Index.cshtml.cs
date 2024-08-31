using BookData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; // Include this for the 'Include' method
using WavePlatform.Models;

namespace WavePlatform.Views.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGetAsync()
        {
            // Fetch books from the database, including their associated authors
            Books = await _context.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddToLibraryAsync(Guid bookId)
        {
            // Replace this with your method of getting the current user's ID
            var userId = GetCurrentUserId();

            // Check if the book is already in the user's library
            bool isBookInLibrary = await _context.UserLibrary
                .AnyAsync(ul => ul.UserId == userId && ul.BookId == bookId);

            if (!isBookInLibrary)
            {
                // Create a new UserLibrary entry for the book
                var userLibrary = new UserLibrary
                {
                    UserId = userId,
                    BookId = bookId,
            //        AddedDate = DateTime.UtcNow
                };

                // Add the new entry to the context
                _context.UserLibrary.Add(userLibrary);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }

            // Redirect to the same page
            return RedirectToPage();
        }

        private Guid GetCurrentUserId()
        {
            // Extract the user ID from the authentication claims
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new InvalidOperationException("User is not authenticated.");
            }

            // Convert the user ID to a GUID
            if (Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                return userId;
            }
            else
            {
                throw new InvalidOperationException("User ID is not in a valid format.");
            }
        }

    }
}
