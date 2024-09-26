using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.LengGridSizePrices
{
    public class CreateModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public CreateModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            //ViewData["GridSizeId"] = new SelectList(_context.GridSizes, "Id", "Size");
            var gridSizes = new SelectList(_context.GridSizes, "Id", "Size");
            ViewData["GridSizeId"] = gridSizes;

            // Set the third GUID from the list as the default selected value (index 2 for zero-based index)
            var gridSizeList = gridSizes.ToList();
            if (gridSizeList.Count >= 3)
            {
                LengthGridSizePrice = new LengthGridSizePrice
                {
                    GridSizeId =Guid.Parse( gridSizeList[8].Value) // Preselect the third item
                };
            }

            ViewData["LengthId"] = new SelectList(_context.Lengths, "Id", "Inch");
            return Page();
        }

        [BindProperty]
        public LengthGridSizePrice LengthGridSizePrice { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LengthGridSizePrice.Add(LengthGridSizePrice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create");
        }
    }
}
