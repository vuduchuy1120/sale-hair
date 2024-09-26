using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.LengthThicknessPrices
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
        ViewData["LengthId"] = new SelectList(_context.Lengths, "Id", "Inch");

        var thickness = new SelectList(_context.Thickness, "Id", "Name");
        ViewData["ThicknessId"] = thickness;

        // Set the third GUID from the list as the default selected value (index 2 for zero-based index)
        var thicknessList = thickness.ToList();
        if (thicknessList.Count >= 1)
        {
            LengThicknessPrice = new LengThicknessPrice
            {
                ThicknessId = Guid.Parse(thicknessList[2].Value) // Preselect the third item
            };
        }


            return Page();
        }

        [BindProperty]
        public LengThicknessPrice LengThicknessPrice { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LengThicknessPrice.Add(LengThicknessPrice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create");
        }
    }
}
