using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.LengGridSizePrices
{
    public class DetailsModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DetailsModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        public LengthGridSizePrice LengthGridSizePrice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lengthgridsizeprice = await _context.LengthGridSizePrice.FirstOrDefaultAsync(m => m.LengthId == id);
            if (lengthgridsizeprice == null)
            {
                return NotFound();
            }
            else
            {
                LengthGridSizePrice = lengthgridsizeprice;
            }
            return Page();
        }
    }
}
