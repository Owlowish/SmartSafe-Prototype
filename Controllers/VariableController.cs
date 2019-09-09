using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smartsafe.Models;

namespace Smartsafe.Controllers
{
    public class VariableController : Controller
    {
        private readonly VariableContext _context;

        public VariableController(VariableContext context)
        {
            _context = context;
        }

        // GET: Variable
        public async Task<IActionResult> Index()
        {
            return View(await _context.Variable.ToListAsync());
        }

        // GET: Variable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variable = await _context.Variable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variable == null)
            {
                return NotFound();
            }

            return View(variable);
        }

        // GET: Variable/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Variable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SignedIn")] Variable variable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(variable);
        }

        // GET: Variable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variable = await _context.Variable.FindAsync(id);
            if (variable == null)
            {
                return NotFound();
            }
            return View(variable);
        }

        // POST: Variable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SignedIn")] Variable variable)
        {
            if (id != variable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariableExists(variable.Id))
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
            return View(variable);
        }

        // GET: Variable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variable = await _context.Variable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variable == null)
            {
                return NotFound();
            }

            return View(variable);
        }

        // POST: Variable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var variable = await _context.Variable.FindAsync(id);
            _context.Variable.Remove(variable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VariableExists(int id)
        {
            return _context.Variable.Any(e => e.Id == id);
        }
    }
}
