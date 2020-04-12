using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Acongrebility.Data;
using Acongrebility.Models;

namespace Acongrebility.Controllers
{
    public class CongressmembersController : Controller
    {
        private readonly AcongrebilityContext _context;

        public CongressmembersController(AcongrebilityContext context)
        {
            _context = context;
        }

        // GET: Congressmembers
        public async Task<IActionResult> Index(string searchString, string congressmemberParty)
        {
            IQueryable<string> partyQuery = from c in _context.Congressmembers
                                            orderby c.Party
                                            select c.Party;

            var congressmembers = from c in _context.Congressmembers
                                  select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                congressmembers = congressmembers.Where(s => s.Name.Contains(searchString));
            }

            return View(await congressmembers.ToListAsync());
        }

        // GET: Congressmembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congressmembers = await _context.Congressmembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (congressmembers == null)
            {
                return NotFound();
            }

            return View(congressmembers);
        }

        // GET: Congressmembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Congressmembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateTookOffice,Role,Pic,Party,VotingHistory")] Congressmembers congressmembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congressmembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congressmembers);
        }

        // GET: Congressmembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congressmembers = await _context.Congressmembers.FindAsync(id);
            if (congressmembers == null)
            {
                return NotFound();
            }
            return View(congressmembers);
        }

        // POST: Congressmembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateTookOffice,Role,Pic,Party,VotingHistory")] Congressmembers congressmembers)
        {
            if (id != congressmembers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congressmembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongressmembersExists(congressmembers.Id))
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
            return View(congressmembers);
        }

        // GET: Congressmembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congressmembers = await _context.Congressmembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (congressmembers == null)
            {
                return NotFound();
            }

            return View(congressmembers);
        }

        // POST: Congressmembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var congressmembers = await _context.Congressmembers.FindAsync(id);
            _context.Congressmembers.Remove(congressmembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongressmembersExists(int id)
        {
            return _context.Congressmembers.Any(e => e.Id == id);
        }
    }
}
