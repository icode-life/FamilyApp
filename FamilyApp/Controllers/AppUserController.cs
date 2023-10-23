using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FamilyApp.Data;
using FamilyApp.Models;

namespace FamilyApp.Controllers
{
    public class AppUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppUser
        public async Task<IActionResult> Index()
        {
              return _context.AppUser != null ? 
                          View(await _context.AppUser.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AppUser'  is null.");
        }

        // GET: AppUser/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AppUser == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // GET: AppUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FirstName")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: AppUser/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AppUser == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUser.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: AppUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,FirstName")] AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserExists(appUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: AppUser/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AppUser == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // POST: AppUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AppUser == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AppUser'  is null.");
            }
            var appUser = await _context.AppUser.FindAsync(id);
            if (appUser != null)
            {
                _context.AppUser.Remove(appUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppUserExists(string id)
        {
          return (_context.AppUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
