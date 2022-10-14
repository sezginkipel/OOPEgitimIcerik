using System.ComponentModel.DataAnnotations;

namespace WebKutuphane.Models
{
    public class BooksViewModel
    {
        // Id's
        public int BookId { get; set; }
        public int GenreId { get; set; }

        // String properties
        public string Title { get; set; }   
        public string Author { get; set; }
        public string GenreName { get; set; }

        // Dates
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = System.DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime UpdatedTime { get; set; } = System.DateTime.Today;

        // Relations
        public Books BooksRef { get; set; }
        public Genres GenresRef { get; set; }

    }
}
