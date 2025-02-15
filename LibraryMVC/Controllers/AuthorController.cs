﻿using LibraryMVC.Data;
using LibraryMVC.Models;
using LibraryMVC.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class AuthorController : Controller

     
    {
        private readonly Context _context;
        public AuthorController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(Author author)
        {
            List<AuthorViewModel> list = _context.Authors.Select(x => new AuthorViewModel
            {
                AuthorName = x.AuthorName,
                AuthorLastName = x.AuthorLastName,
                AuthorInfo = x.AuthorInfo,
                Id =x.AuthorId,
                
            }).ToList();
            return View(list);
        }

        
        public IActionResult AddAuthor()
        {
  
            return View();
        }
        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            Author author = _context.Authors.Find(Id);
            _context.Remove(author);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
