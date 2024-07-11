using LibraryMVC.Data;
using LibraryMVC.Models.View;
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

        public IActionResult Index(BookViewModel bookViewModel,string Keyword)
        {
            //string Keyword = "Ola";
            List<BookViewModel> books;

            if (string.IsNullOrEmpty(Keyword))

            {
               
                books = _context.Books.Select(x=> new BookViewModel
                {
                    BookName = x.BookName, 
                    AuthorName = x.Author.FullName,
                    CategoryName = x.Category.CategoryName,
                    BookPrice = x.BookPrice,
                    RealaseDate = x.RealseDate,
                }).ToList();

               
            }
            else
            {
                books = _context.Books
                .Include(x=>x.Author)
                .Include(x=>x.Category)
                .AsEnumerable()
                .Where(x => x.BookName.Contains(Keyword) ||
                          x.Category.CategoryName.Contains(Keyword) ||
                          x.Author.AuthorName.Contains(Keyword)
                )
                .Select(book => new BookViewModel
                {
                    BookName = book.BookName,
                    AuthorName = book.Author.FullName,
                    CategoryName = book.Category.CategoryName,
                    BookPrice = book.BookPrice,
                    RealaseDate = book.RealseDate
                }
                ).ToList();
                
            }

            return View(books);


            
        }
    }
}
