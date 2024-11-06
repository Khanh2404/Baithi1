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
    public class LoaiGiaysController : Controller
    {
        private readonly ShopGiayContext _context;

        public LoaiGiaysController(ShopGiayContext context)
        {
            _context = context;
        }

        // GET: LoaiGiays
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.LoaiGiay == null)
            {
                return Problem("Entity set 'ShopGiayContext.ChiTietGiay'  is null.");
            }

            var LoaiGiays = from m in _context.LoaiGiay
                               select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                LoaiGiays = LoaiGiays.Where(s => s.TenLoai!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await LoaiGiays.ToListAsync());
        }

        // GET: LoaiGiays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiGiay = await _context.LoaiGiay
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loaiGiay == null)
            {
                return NotFound();
            }

            return View(loaiGiay);
        }

        // GET: LoaiGiays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiGiays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,MoTa")] LoaiGiay loaiGiay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiGiay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiGiay);
        }

        // GET: LoaiGiays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiGiay = await _context.LoaiGiay.FindAsync(id);
            if (loaiGiay == null)
            {
                return NotFound();
            }
            return View(loaiGiay);
        }

        // POST: LoaiGiays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenLoai,MoTa")] LoaiGiay loaiGiay)
        {
            if (id != loaiGiay.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiGiay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiGiayExists(loaiGiay.MaLoai))
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
            return View(loaiGiay);
        }

        // GET: LoaiGiays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiGiay = await _context.LoaiGiay
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loaiGiay == null)
            {
                return NotFound();
            }

            return View(loaiGiay);
        }

        // POST: LoaiGiays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiGiay = await _context.LoaiGiay.FindAsync(id);
            if (loaiGiay != null)
            {
                _context.LoaiGiay.Remove(loaiGiay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiGiayExists(int id)
        {
            return _context.LoaiGiay.Any(e => e.MaLoai == id);
        }
    }
}
