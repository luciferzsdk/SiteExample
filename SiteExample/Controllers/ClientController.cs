using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteExample.Data;
using SiteExample.Models;

namespace SiteExample.Controllers
{
    public class ClientController : Controller
    {
        private readonly MyAppContext _context;

        public ClientController(MyAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var client = await _context.Clients.ToListAsync();

            return View(client);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {

            }

            return View(client);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Update(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {

            }

            return View(client);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
            else
            {

            }

            return RedirectToAction("Index");
        }
    }
}
