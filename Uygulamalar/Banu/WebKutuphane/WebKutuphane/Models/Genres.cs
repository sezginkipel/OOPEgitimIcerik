using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebKutuphane.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
