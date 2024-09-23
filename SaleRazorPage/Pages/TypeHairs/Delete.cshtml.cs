using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.TypeHairs
{
    public class DeleteModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DeleteModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypeHair TypeHair { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typehair = await _context.TypeHairs.FirstOrDefaultAsync(m => m.Id == id);

            if (typehair == null)
            {
                return NotFound();
            }
            else
            {
                TypeHair = typehair;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typehair = await _context.TypeHairs.FindAsync(id);
            if (typehair != null)
            {
                TypeHair = typehair;
                _context.TypeHairs.Remove(TypeHair);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
