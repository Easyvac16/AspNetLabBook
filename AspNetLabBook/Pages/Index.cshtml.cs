using AspNetLabBook.Abstract;
using AspNetLabBook.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetLabBook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBookOutputSaveService _bookOutputSaveService;
        public Book Book { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public IndexModel(IBookOutputSaveService bookOutputSaveService)
        {
            _bookOutputSaveService = bookOutputSaveService;
        }

        public void OnGet()
        {
            Book book = new Book()
            {
                AuthorName = "Json1",
                Genre = "Json2",
                Publisher = "Json3",
                ReleaseYear = 1488,
                Title = "Title"
            };

            //_bookOutputSaveService.WriteToJsonFile(book, "books.json");
            Books = _bookOutputSaveService.ReadFromJsonFile("books.json");
        }
    }
}
