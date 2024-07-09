using LibraryMVC.Data;
using LibraryMVC.Models;
using Microsoft.AspNetCore.Mvc;
using LibraryMVC.Models.View;

namespace LibraryMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Context _context;
        public CategoryController(Context context)
        {
            _context = context;
        }
        public IActionResult Index(Category category)

        {
            List<CategoryViewModel> listcategories = _context.Categories.Select
                (
                x => new CategoryViewModel
                    {
                CategoryName = x.CategoryName,
                    }
                ).ToList();
            return View(listcategories);
        }

        public IActionResult AddCategory() 
        {
        return View();
        }

        [HttpPost] 
        public IActionResult AddCategory(Category category)
        {
            
            _context.Categories.Add(category);
            _context.SaveChanges();
            return View();
        }
    }
}
