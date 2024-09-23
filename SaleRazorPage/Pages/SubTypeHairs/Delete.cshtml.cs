using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.SubTypeHairs
{
    public class DeleteModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DeleteModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubTypeHair SubTypeHair { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subtypehair = await _context.SubTypeHairs.FirstOrDefaultAsync(m => m.ColorId == id);

            if (subtypehair == null)
            {
                return NotFound();
            }
            else
            {
                SubTypeHair = subtypehair;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subtypehair = await _context.SubTypeHairs.FindAsync(id);
            if (subtypehair != null)
            {
                SubTypeHair = subtypehair;
                _context.SubTypeHairs.Remove(SubTypeHair);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
