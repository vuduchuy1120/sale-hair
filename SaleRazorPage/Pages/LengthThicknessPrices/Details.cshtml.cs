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
    public class DetailsModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DetailsModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
