using LibraryMVC.Data;
using LibraryMVC.Models;
using LibraryMVC.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly Context _context;
        public BookController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List < BookViewModel > bList= _context.Books.Include(x => x.Category)
                                                        .Select(x => new BookViewModel
            {
                BookName = x.BookName,
                BookPrice = x.BookPrice,
                CategoryName = x.Category.CategoryName


            }).ToList();

            return View(bList); 
        }



        public IActionResult BookCrate()
        {

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorID", "FullName");

            return View();
        }

        [HttpPost]
        public IActionResult BookCrate(BookInputView bookInputView)
        {
            Book book = new Book();
            book.BookName = bookInputView.BookName;
            book.BookPrice = bookInputView.BookPrice;
            book.RealseDate=bookInputView.RelaseDate;
            book.CategoryId = bookInputView.CategoryId;
            book.AuthorId = bookInputView.AuthorId;
            book.ImagePath = bookInputView.ImagePath;

            //string FileName = book.Image.FileName;
            //Guid guid = Guid.NewGuid();
            //FileName = guid+"_"+FileName;

            //FileStream fs = new FileStream("wwwroot/BookImage/"+FileName , FileMode.Create);
            //book.Image.CopyTo(fs);
            //fs.Close();
            //book.ImagePath = FileName;

            _context.Books.Add(book);
            _context.SaveChanges();

            return View();
        }

    }
}
