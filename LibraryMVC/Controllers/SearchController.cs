using LibraryMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly Context _context;
        public SearchController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(string Keyword)
        {
            var books = from book in _context.Books.Include(x => x.Author).Include(x => x.Category) select book;

            if (!string.IsNullOrEmpty(Keyword))
            {
                books = books.Where(books => books.BookName.Contains(Keyword));
            }



            return View(books.ToList());
        }
    }
}
