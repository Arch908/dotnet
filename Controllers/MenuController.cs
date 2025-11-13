using FoodMenu.Data;
using FoodMenu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FoodMenu.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MenuController(ApplicationDbContext db) => _db = db;

        // GET: /Menu
        public async Task<IActionResult> Index()
        {
            var items = await _db.MenuItems.ToListAsync();
            return View(items);
        }

        // GET: /Menu/Create
        [Authorize]
        [HttpGet]
        public IActionResult Create() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuItem model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.MenuItems.Add(model);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Menu/Edit/5
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _db.MenuItems.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MenuItem model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            _db.MenuItems.Update(model);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Menu/Delete/5
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.MenuItems.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _db.MenuItems.FindAsync(id);
            if (item != null)
            {
                _db.MenuItems.Remove(item);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
