using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopGiay.Data;
using ShopGiay.Models;

namespace ShopGiay.Controllers
{
    public class ChiTietGiaysController : Controller
    {
        private readonly ShopGiayContext _context;

        public ChiTietGiaysController(ShopGiayContext context)
        {
            _context = context;
        }

        // GET: ChiTietGiays
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.ChiTietGiay  == null)
            {
                return Problem("Entity set 'ShopGiayContext.ChiTietGiay'  is null.");
            }

            var ChiTietGiays = from m in _context.ChiTietGiay
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                ChiTietGiays = ChiTietGiays.Where(s => s.TenGiay!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await ChiTietGiays.ToListAsync());
        }

        // GET: ChiTietGiays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietGiay = await _context.ChiTietGiay
                .FirstOrDefaultAsync(m => m.MaGiay == id);
            if (chiTietGiay == null)
            {
                return NotFound();
            }

            return View(chiTietGiay);
        }

        // GET: ChiTietGiays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChiTietGiays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGiay,TenGiay,KichCo,MauSac,Gia,MaLoaiGiay")] ChiTietGiay chiTietGiay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietGiay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chiTietGiay);
        }

        // GET: ChiTietGiays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietGiay = await _context.ChiTietGiay.FindAsync(id);
            if (chiTietGiay == null)
            {
                return NotFound();
            }
            return View(chiTietGiay);
        }

        // POST: ChiTietGiays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGiay,TenGiay,KichCo,MauSac,Gia,MaLoaiGiay")] ChiTietGiay chiTietGiay)
        {
            if (id != chiTietGiay.MaGiay)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietGiay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietGiayExists(chiTietGiay.MaGiay))
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
            return View(chiTietGiay);
        }

        // GET: ChiTietGiays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietGiay = await _context.ChiTietGiay
                .FirstOrDefaultAsync(m => m.MaGiay == id);
            if (chiTietGiay == null)
            {
                return NotFound();
            }

            return View(chiTietGiay);
        }

        // POST: ChiTietGiays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietGiay = await _context.ChiTietGiay.FindAsync(id);
            if (chiTietGiay != null)
            {
                _context.ChiTietGiay.Remove(chiTietGiay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietGiayExists(int id)
        {
            return _context.ChiTietGiay.Any(e => e.MaGiay == id);
        }
    }
}
