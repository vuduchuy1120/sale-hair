using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.LengGridSizePrices
{
    public class EditModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public EditModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LengthGridSizePrice LengthGridSizePrice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lengthgridsizeprice =  await _context.LengthGridSizePrice.FirstOrDefaultAsync(m => m.LengthId == id);
            if (lengthgridsizeprice == null)
            {
                return NotFound();
            }
            LengthGridSizePrice = lengthgridsizeprice;
           ViewData["GridSizeId"] = new SelectList(_context.GridSizes, "Id", "Id");
           ViewData["LengthId"] = new SelectList(_context.Lengths, "Id", "Id");
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

            _context.Attach(LengthGridSizePrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LengthGridSizePriceExists(LengthGridSizePrice.LengthId))
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

        private bool LengthGridSizePriceExists(Guid id)
        {
            return _context.LengthGridSizePrice.Any(e => e.LengthId == id);
        }
    }
}
