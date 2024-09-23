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
    public class DeleteModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DeleteModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorythickness = await _context.CategoryThickness.FindAsync(id);
            if (categorythickness != null)
            {
                CategoryThickness = categorythickness;
                _context.CategoryThickness.Remove(CategoryThickness);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
