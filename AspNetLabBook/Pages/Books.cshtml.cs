using AspNetLabBook.Abstract;
using AspNetLabBook.Model;
using AspNetLabBook.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetLabBook.Pages
{
    public class BooksModel : PageModel
    {
        public IBookOutputSaveService BookOutputSave;

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            BookOutputSave = new BookOutputSaveService();


            if (BookOutputSave.GetBooks().Count == 0)
            {
                BookOutputSave.AddBook(new Book("Sir Lawrance Hedgecliff", "Martyr of the Stray Dogs", "Mystery", "Gloverb", 1978));
                BookOutputSave.AddBook(new Book("Bonney Betty Belle", "Close the Door on the Way Out", "Comedy", "Practicality", 2008));
                BookOutputSave.AddBook(new Book("Prosketti Marcippio", "Swords Crossed", "Romance", "Practicality", 2005));
            }
        }
        public void OnGet()
        {

        }
    }
}
