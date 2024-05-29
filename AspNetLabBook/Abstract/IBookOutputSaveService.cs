using AspNetLabBook.Model;

namespace AspNetLabBook.Abstract
{
    public interface IBookOutputSaveService
    {
        public List<Book> ReadFromJsonFile(string filePath);
        public void WriteToJsonFile(Book book, string filePath);
        public void WriteToJsonFile(List<Book> books, string filePath);
        public List<Book> GetBooks();
        public void AddBook(Book book);
        public void DeleteBookFromJSON(Book book);
        public Book FindBook(Book BookToFind);
        public void UpdateBook(Book book, Book BookToUpdate);
    }
}
