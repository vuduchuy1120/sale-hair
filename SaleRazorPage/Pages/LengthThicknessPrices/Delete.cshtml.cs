using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.LengthThicknessPrices
{
    public class DeleteModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DeleteModel(SaleRazorPage.Model.AppDbContext context)
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

            var lengthicknessprice = await _context.LengThicknessPrice.FirstOrDefaultAsync(m => m.LengthId == id);

            if (lengthicknessprice == null)
            {
                return NotFound();
            }
            else
            {
                LengThicknessPrice = lengthicknessprice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lengthicknessprice = await _context.LengThicknessPrice.FindAsync(id);
            if (lengthicknessprice != null)
            {
                LengThicknessPrice = lengthicknessprice;
                _context.LengThicknessPrice.Remove(LengThicknessPrice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
