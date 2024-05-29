using AspNetLabBook.Abstract;
using AspNetLabBook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetLabBook.Pages
{
    public class BooksInfoModel : PageModel
    {
        private readonly IBookOutputSaveService BookOutputSave;

        public BooksInfoModel(IBookOutputSaveService bookOutputSave)
        {
            BookOutputSave = bookOutputSave;
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public Book BookToUpdate { get; set; }

        public IActionResult OnGet(string title, string genre, string author, string publisher, int year)
        {
            Book = new Book(title, genre, author, publisher, year);

            BookToUpdate = new Book
            {
                AuthorName = Book.AuthorName,
                Title = Book.Title,
                Genre = Book.Genre,
                Publisher = Book.Publisher,
                ReleaseYear = Book.ReleaseYear
            };

            return Page();  
        }

        public IActionResult OnPostDelete()
        {
            if (ModelState.IsValid)
            {
                BookOutputSave.DeleteBookFromJSON(Book);
                return RedirectToPage("/Books");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                BookOutputSave.UpdateBook(Book, BookToUpdate);
                return RedirectToPage("/Books");
            }
            return Page();
        }
    }
}
