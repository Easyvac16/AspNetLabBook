namespace AspNetLabBook.Model
{
    public class Book
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int ReleaseYear { get; set; }

        public Book()
        {

        }

        public Book(string authorName, string title, string genre, string publisher, int releaseYear)
        {
            AuthorName = authorName;
            Title = title;
            Genre = genre;
            Publisher = publisher;
            ReleaseYear = releaseYear;
        }

        public override string ToString()
        {
            return $"Author:{AuthorName} Title:{Title} Genre:{Genre} Publisher:{Publisher} Year:{ReleaseYear}";
        }
        
    }
}
