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
    public class TestatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestatorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Testators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testators.ToListAsync());
        }

        // GET: Testators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testator = await _context.Testators.SingleOrDefaultAsync(m => m.ID == id);
            if (testator == null)
            {
                return NotFound();
            }

            return View(testator);
        }

        // GET: Testators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,MiddleName,Occupation,PostCode,State,StreetName,StreetNumber,StreetType,Suburb")] Testator testator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testator);
        }

        // GET: Testators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testator = await _context.Testators.SingleOrDefaultAsync(m => m.ID == id);
            if (testator == null)
            {
                return NotFound();
            }
            return View(testator);
        }

        // POST: Testators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,MiddleName,Occupation,PostCode,State,StreetName,StreetNumber,StreetType,Suburb")] Testator testator)
        {
            if (id != testator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestatorExists(testator.ID))
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
            return View(testator);
        }

        // GET: Testators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testator = await _context.Testators.SingleOrDefaultAsync(m => m.ID == id);
            if (testator == null)
            {
                return NotFound();
            }

            return View(testator);
        }

        // POST: Testators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testator = await _context.Testators.SingleOrDefaultAsync(m => m.ID == id);
            _context.Testators.Remove(testator);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TestatorExists(int id)
        {
            return _context.Testators.Any(e => e.ID == id);
        }
    }
}
