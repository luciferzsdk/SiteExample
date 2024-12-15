using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteExample.Data;
using SiteExample.Models;

namespace SiteExample.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyAppContext _context;

        public CategoryController(MyAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var client = await _context.Categories.ToListAsync();

            return View(client);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {

            }

            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {

            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            else
            {

            }

            return RedirectToAction("Index");
        }
    }
}
