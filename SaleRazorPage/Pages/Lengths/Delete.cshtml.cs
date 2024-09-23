using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.Lengths
{
    public class DeleteModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DeleteModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Length Length { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var length = await _context.Lengths.FirstOrDefaultAsync(m => m.Id == id);

            if (length == null)
            {
                return NotFound();
            }
            else
            {
                Length = length;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var length = await _context.Lengths.FindAsync(id);
            if (length != null)
            {
                Length = length;
                _context.Lengths.Remove(Length);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
