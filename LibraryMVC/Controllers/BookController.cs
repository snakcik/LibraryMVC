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
            List < BookViewModel > bList= _context.Books
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Select(x => new BookViewModel
                {
                    BookName = x.BookName,
                    BookPrice = x.BookPrice,
                    CategoryName = x.Category.CategoryName,
                    AuthorName= x.Author.FullName,
                    Id = x.BookId
                    
                }
               ).ToList();

            return View(bList); 
        }



        public IActionResult BookCrate()
        {

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            //ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorID", "FullName");
            ViewBag.Author = new SelectList(_context.Authors, "AuthorId", "FullName");

            return View();
        }

        [HttpPost]
        public IActionResult BookCrate(BookInputModel bookInputModel)
        {
            Book book = new Book();
            book.BookName = bookInputModel.BookName;
            book.BookPrice = bookInputModel.BookPrice;
            book.RealseDate = bookInputModel.RelaseDate;
            book.CategoryId = bookInputModel.CategoryId;
            book.AuthorId = bookInputModel.AuthorId;

            //string FileName = bookInputModel.ImagePath;
            //Guid guid = Guid.NewGuid();
            //FileName = guid + "_" + FileName;

            //FileStream fs = new FileStream("wwwroot/BookImage/" + FileName, FileMode.Create);
            //book.Image.CopyTo(fs);
            //fs.Close();
            //book.ImagePath = FileName;
            bool hataolustu = true;
            if (bookInputModel.BookName == null)          
            { ViewBag.BookName = false;
                hataolustu = false;
            }
            if(bookInputModel.BookPrice ==null)
             {   ViewBag.Price = false;
                hataolustu = false;
             }
            if (bookInputModel.RelaseDate ==null)
                {
                ViewBag.RelaseDate = false;
                hataolustu = false;
                }
            if (bookInputModel.CategoryId == null)
                {
                ViewBag.CategoryId = false;
                hataolustu = false;
                 }
            if (bookInputModel.AuthorId == null)
                {
                ViewBag.AuthorId = false;
                hataolustu = false;
                 }
            if(hataolustu !=false)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            else
              { return RedirectToAction("BookCrate"); }

         
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int Id)
        {
            Book book = _context.Books.Find(Id);

            _context.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
