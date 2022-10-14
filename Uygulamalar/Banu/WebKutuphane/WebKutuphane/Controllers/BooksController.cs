using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebKutuphane.Data;
using WebKutuphane.Models;

namespace WebKutuphane.Controllers
{
    public class BooksController : Controller
    {
        private readonly WebKutuphaneContext _context;

        public BooksController(WebKutuphaneContext context)
        {
            _context = context;
        }

        // GET: Books 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.Include(m => m.Genres).ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            PopulateGenresDropDownList();
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Books books)
        {
          
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            // return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books.Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);
            /*
             var books kısmında FindAsync kullanınca Include çalışmıyor, çünkü FindAsync metodu Dbset
            içerisinden geliyor ancak Include metodu IQueryable içerisinden geliyor ve birlikte kullanılamıyorlar.  
             */


            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Books books)
        {
         
            if (id != books.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(books);
        }

        

            
            // GET: Books/Delete/5
            public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'WebKutuphaneContext.Books'  is null.");
            }
            var books = await _context.Books.FindAsync(id);
            if (books != null)
            {
                _context.Books.Remove(books);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
          return _context.Books.Any(e => e.Id == id);
        }

        private void PopulateGenresDropDownList(object selectedGenres = null)
        {
            var booksQuery = from d in _context.Genres
                                   orderby d.Name
                                   select d;
            ViewBag.Id = new SelectList(booksQuery.AsNoTracking(), "Id", "Name", selectedGenres);
        }
    }
}
