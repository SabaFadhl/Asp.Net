using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WebUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WebUsers
        public async Task<IActionResult> Index()
        {
              return _context.WebUsers != null ? 
                          View(await _context.WebUsers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.WebUsers'  is null.");
        }

        // GET: WebUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WebUsers == null)
            {
                return NotFound();
            }

            var webUser = await _context.WebUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webUser == null)
            {
                return NotFound();
            }

            return View(webUser);
        }

        // GET: WebUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Password,Country,Age,UImage")] WebUser webUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webUser);
        }

        // GET: WebUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WebUsers == null)
            {
                return NotFound();
            }

            var webUser = await _context.WebUsers.FindAsync(id);
            if (webUser == null)
            {
                return NotFound();
            }
            return View(webUser);
        }

        // POST: WebUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Password,Country,Age,UImage")] WebUser webUser)
        {
            if (id != webUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebUserExists(webUser.Id))
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
            return View(webUser);
        }

        // GET: WebUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WebUsers == null)
            {
                return NotFound();
            }

            var webUser = await _context.WebUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webUser == null)
            {
                return NotFound();
            }

            return View(webUser);
        }

        // POST: WebUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WebUsers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WebUsers'  is null.");
            }
            var webUser = await _context.WebUsers.FindAsync(id);
            if (webUser != null)
            {
                _context.WebUsers.Remove(webUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebUserExists(int id)
        {
          return (_context.WebUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
