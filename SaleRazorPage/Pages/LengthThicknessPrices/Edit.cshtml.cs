using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.LengthThicknessPrices
{
    public class EditModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public EditModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LengThicknessPrice LengThicknessPrice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lengthicknessprice =  await _context.LengThicknessPrice.FirstOrDefaultAsync(m => m.LengthId == id);
            if (lengthicknessprice == null)
            {
                return NotFound();
            }
            LengThicknessPrice = lengthicknessprice;
           ViewData["LengthId"] = new SelectList(_context.Lengths, "Id", "Id");
           ViewData["ThicknessId"] = new SelectList(_context.Thickness, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LengThicknessPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LengThicknessPriceExists(LengThicknessPrice.LengthId))
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

        private bool LengThicknessPriceExists(Guid id)
        {
            return _context.LengThicknessPrice.Any(e => e.LengthId == id);
        }
    }
}
