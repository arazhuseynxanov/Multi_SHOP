using Microsoft.AspNetCore.Mvc;
using MultiShop.DAL;
using MultiShop.Models;

namespace MultiShop.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ColorController : Controller
    {
        readonly AppDbContext _context;
        public ColorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Colors.ToList());
        }

        public IActionResult Delete(int id)
        {
            Color color = _context.Colors.Find(id);
            if (color is null) return NotFound();
            _context.Colors.Remove(color);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color color)
        {
            if (!ModelState.IsValid) return View();
            _context.Colors.Add(color);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            Color color = _context.Colors.Find(id);
            if (color is null) return NotFound();
            return View(color);
        }

        [HttpPost]
        public IActionResult Update(int? id, Color color)
        {
            if (!ModelState.IsValid) return View();
            if (id is null || id != color.Id) return BadRequest();
            Color exicolor = _context.Colors.Find(id);
            if (color is null) return NotFound();
            exicolor.Name = color.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
