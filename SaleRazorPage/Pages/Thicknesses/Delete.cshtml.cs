using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.Thicknesses
{
    public class DeleteModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DeleteModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Thickness Thickness { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thickness = await _context.Thickness.FirstOrDefaultAsync(m => m.Id == id);

            if (thickness == null)
            {
                return NotFound();
            }
            else
            {
                Thickness = thickness;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thickness = await _context.Thickness.FindAsync(id);
            if (thickness != null)
            {
                Thickness = thickness;
                _context.Thickness.Remove(Thickness);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
