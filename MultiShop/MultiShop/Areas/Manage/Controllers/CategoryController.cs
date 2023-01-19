using Microsoft.AspNetCore.Mvc;
using MultiShop.DAL;
using MultiShop.Models;

namespace MultiShop.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category is null) return NotFound();
            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            Category category = _context.Categories.Find(id);
            if (category is null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(int? id, Category category)
        {
            if(!ModelState.IsValid) return View();
            if(id==null|| id<=0) return BadRequest();
            Category exicategory= _context.Categories.Find(id);
            if(exicategory is null) return NotFound();
            exicategory.Name=category.Name;
            exicategory.ImageUrl=category.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
