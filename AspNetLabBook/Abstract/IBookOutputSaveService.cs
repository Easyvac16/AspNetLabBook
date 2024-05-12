using AspNetLabBook.Model;

namespace AspNetLabBook.Abstract
{
    public interface IBookOutputSaveService
    {
        public List<Book> ReadFromJsonFile(string filePath);
        public void WriteToJsonFile(Book book, string filePath);
        public void RemoveBook(string filePath);
        public List<Book> GetBooks();
        public void AddBook(Book book);
    }
}
