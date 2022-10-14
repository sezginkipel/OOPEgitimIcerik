using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebKutuphane.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }

       public int GenresId { get; set; }
        public Genres Genres { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedTime { get; set; }



 

    }
}
