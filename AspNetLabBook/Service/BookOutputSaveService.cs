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
        public void RemoveBook(string filePath)
        {
            Console.WriteLine("LVA");
        }

        public List<Book> GetBooks() => _books;

        public void AddBook(Book book) => WriteToJsonFile(book,"books.json");
    }
}
