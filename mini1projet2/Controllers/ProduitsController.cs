using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mini1projet2.Data;
using mini1projet2.Models;

namespace mini1projet2.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly mini1projet2Context _context;

        public ProduitsController(mini1projet2Context context)
        {
            _context = context;
        }

        // GET: Produits
        public async Task<IActionResult> Index()
        {
              return View(await _context.Produit.ToListAsync());
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit
                .FirstOrDefaultAsync(m => m.ProduitID == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }
        public void ADD(int id)
        {
            //return _context.Produit.Any(e => e.ProduitID == id);

            _context.LignePanier.Add(new LignePanier { Quantite = 100, PanierID = 1, ProduitID = id });
            _context.SaveChanges();
        }
        // GET: Produits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduitID,Nom,Price")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // GET: Produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduitID,Nom,Price")] Produit produit)
        {
            if (id != produit.ProduitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitExists(produit.ProduitID))
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
            return View(produit);
        }

        // GET: Produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit
                .FirstOrDefaultAsync(m => m.ProduitID == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produit == null)
            {
                return Problem("Entity set 'mini1projet2Context.Produit'  is null.");
            }
            var produit = await _context.Produit.FindAsync(id);
            if (produit != null)
            {
                _context.Produit.Remove(produit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitExists(int id)
        {

          return _context.Produit.Any(e => e.ProduitID == id);
        }
       
    }
   
}
