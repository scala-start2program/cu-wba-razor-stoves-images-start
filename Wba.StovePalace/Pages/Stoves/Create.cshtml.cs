using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wba.StovePalace.Data;
using Wba.StovePalace.Models;

namespace Wba.StovePalace.Pages.Stoves
{
    public class CreateModel : PageModel
    {
        private readonly Wba.StovePalace.Data.StoveContext _context;

        public CreateModel(Wba.StovePalace.Data.StoveContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BrandId"] = new SelectList(_context.Brand.OrderBy(b=>b.BrandName).ToList(), "Id", "BrandName");
        ViewData["FuelId"] = new SelectList(_context.Fuel.OrderBy(b => b.FuelName).ToList(), "Id", "FuelName");
            return Page();
        }

        [BindProperty]
        public Stove Stove { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stove.Add(Stove);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
