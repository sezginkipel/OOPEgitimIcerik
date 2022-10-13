using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebKutuphane.Models;

namespace WebKutuphane.Data
{
    public class WebKutuphaneContext : DbContext
    {
        public WebKutuphaneContext (DbContextOptions<WebKutuphaneContext> options)
            : base(options)
        {
        }

        public DbSet<WebKutuphane.Models.Books> Books { get; set; } = default!;
        public DbSet<WebKutuphane.Models.Genres> Genres { get; set; } = default!;
    }
}
