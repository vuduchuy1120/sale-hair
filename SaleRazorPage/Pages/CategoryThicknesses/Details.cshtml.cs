using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.CategoryThicknesses
{
    public class DetailsModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DetailsModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        public CategoryThickness CategoryThickness { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorythickness = await _context.CategoryThickness.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categorythickness == null)
            {
                return NotFound();
            }
            else
            {
                CategoryThickness = categorythickness;
            }
            return Page();
        }
    }
}
