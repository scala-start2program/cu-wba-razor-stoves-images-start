using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wba.StovePalace.Data;
using Wba.StovePalace.Models;

namespace Wba.StovePalace.Pages.Stoves
{
    public class EditModel : PageModel
    {
        private readonly Wba.StovePalace.Data.StoveContext _context;

        public EditModel(Wba.StovePalace.Data.StoveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stove Stove { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stove = await _context.Stove
                .Include(s => s.Brand)
                .Include(s => s.Fuel).FirstOrDefaultAsync(m => m.Id == id);

            if (Stove == null)
            {
                return NotFound();
            }
           ViewData["BrandId"] = new SelectList(_context.Brand.OrderBy(b=>b.BrandName).ToList(), "Id", "BrandName");
           ViewData["FuelId"] = new SelectList(_context.Fuel.OrderBy(f=>f.FuelName).ToList(), "Id", "FuelName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stove).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoveExists(Stove.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StoveExists(int id)
        {
            return _context.Stove.Any(e => e.Id == id);
        }
    }
}
