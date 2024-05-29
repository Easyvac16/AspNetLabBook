using AspNetLabBook.Abstract;
using AspNetLabBook.Model;
using Newtonsoft.Json;

namespace AspNetLabBook.Service
{
    public class BookOutputSaveService : IBookOutputSaveService
    {
        List<Book> _books;

        public BookOutputSaveService()
        {
            _books = ReadFromJsonFile("books.json");
        }

        public Book FindBook(Book bookToFind)
        {
            return _books.FirstOrDefault(f =>
                f.AuthorName == bookToFind.AuthorName &&
                f.Title == bookToFind.Title &&
                f.Genre == bookToFind.Genre &&
                f.Publisher == bookToFind.Publisher &&
                f.ReleaseYear == bookToFind.ReleaseYear);
        }

        public List<Book> ReadFromJsonFile(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Book>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні JSON-файлу: {ex.Message}");
                return new List<Book>();
            }
        }
        public void WriteToJsonFile(Book book, string filePath)
        {
            List<Book> books = new List<Book>();

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    books = JsonConvert.DeserializeObject<List<Book>>(jsonString);
                }
            }

            books.Add(book);

            string updatedJson = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

        }
        
        public void WriteToJsonFile(List<Book> books, string filePath)
        {
            string updatedJson = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
        public void DeleteBookFromJSON(Book book)
        {
            _books.RemoveAll(f =>
                f.AuthorName == book.AuthorName &&
                f.Title == book.Title &&
                f.Genre == book.Genre &&
                f.Publisher == book.Publisher &&
                f.ReleaseYear == book.ReleaseYear);

            WriteToJsonFile(_books, "books.json");
        }

        public void UpdateBook(Book book, Book BookToUpdate)
        {
            DeleteBookFromJSON(book);

            WriteToJsonFile(BookToUpdate, "books.json");
        }

        public List<Book> GetBooks() => _books;

        public void AddBook(Book book) => WriteToJsonFile(book,"books.json");
    }
}
