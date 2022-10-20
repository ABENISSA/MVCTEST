using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Login.Data;
using Login.Models;

namespace Login.Controllers
{
    public class ManagementsController : Controller
    {
        private readonly LocalTrainingContext _context;

        public ManagementsController(LocalTrainingContext context)
        {
            _context = context;
        }

        // GET: Managements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Managements.ToListAsync());
        }

        // GET: Managements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var management = await _context.Managements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (management == null)
            {
                return NotFound();
            }

            return View(management);
        }

        // GET: Managements/Create
        public IActionResult Create()
        {
            int id = (_context.Managements.Select(x=>(int?)x.Id).Max() ?? 0) + 1;
            ViewBag.id = id;
            int orderid = (_context.Managements.Select(x => (int?)x.Id).Max() ?? 0) + 1;
            ViewBag.id = id;
            return View();
        }

        // POST: Managements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OrdererId")] Management management)
        {
            if (ModelState.IsValid)
            {
                _context.Add(management);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(management);
        }

        // GET: Managements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var management = await _context.Managements.FindAsync(id);
            if (management == null)
            {
                return NotFound();
            }
            return View(management);
        }

        // POST: Managements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,OrdererId")] Management management)
        {
            if (id != management.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(management);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagementExists(management.Id))
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
            return View(management);
        }

        // GET: Managements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var management = await _context.Managements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (management == null)
            {
                return NotFound();
            }

            return View(management);
        }

        // POST: Managements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var management = await _context.Managements.FindAsync(id);
            _context.Managements.Remove(management);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagementExists(int id)
        {
            return _context.Managements.Any(e => e.Id == id);
        }
    }
}
