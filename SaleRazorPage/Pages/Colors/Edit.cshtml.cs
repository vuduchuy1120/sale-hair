using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.Colors
{
    public class EditModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public EditModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Color Color { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color =  await _context.Colors.FirstOrDefaultAsync(m => m.Id == id);
            if (color == null)
            {
                return NotFound();
            }
            Color = color;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(Color.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ColorExists(Guid id)
        {
            return _context.Colors.Any(e => e.Id == id);
        }
    }
}
