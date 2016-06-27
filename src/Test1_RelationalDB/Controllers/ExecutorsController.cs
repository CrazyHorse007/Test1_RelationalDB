using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test1_RelationalDB.Data;
using Test1_RelationalDB.Models;

namespace Test1_RelationalDB.Controllers
{
    public class ExecutorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExecutorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Executors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Executors.Include(e => e.Testator);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Executors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors.SingleOrDefaultAsync(m => m.ID == id);
            if (executor == null)
            {
                return NotFound();
            }

            return View(executor);
        }

        // GET: Executors/Create
        public IActionResult Create()
        {
            ViewData["TestatorID"] = new SelectList(_context.Testators, "ID", "Testator");
            return View();
        }

        // POST: Executors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,MiddleName,PostCode,Relationship,State,StreetName,StreetNumber,StreetType,Suburb,TestatorID")] Executor executor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(executor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TestatorID"] = new SelectList(_context.Testators, "ID", "Testator", executor.TestatorID);
            return View(executor);
        }

        // GET: Executors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors.SingleOrDefaultAsync(m => m.ID == id);
            if (executor == null)
            {
                return NotFound();
            }
            ViewData["TestatorID"] = new SelectList(_context.Testators, "ID", "Testator", executor.TestatorID);
            return View(executor);
        }

        // POST: Executors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,MiddleName,PostCode,Relationship,State,StreetName,StreetNumber,StreetType,Suburb,TestatorID")] Executor executor)
        {
            if (id != executor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(executor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecutorExists(executor.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["TestatorID"] = new SelectList(_context.Testators, "ID", "Testator", executor.TestatorID);
            return View(executor);
        }

        // GET: Executors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors.SingleOrDefaultAsync(m => m.ID == id);
            if (executor == null)
            {
                return NotFound();
            }

            return View(executor);
        }

        // POST: Executors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var executor = await _context.Executors.SingleOrDefaultAsync(m => m.ID == id);
            _context.Executors.Remove(executor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ExecutorExists(int id)
        {
            return _context.Executors.Any(e => e.ID == id);
        }
    }
}
