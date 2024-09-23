using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.SubTypeHairs
{
    public class EditModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public EditModel(SaleRazorPage.Model.AppDbContext context)
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

            var subtypehair =  await _context.SubTypeHairs.FirstOrDefaultAsync(m => m.ColorId == id);
            if (subtypehair == null)
            {
                return NotFound();
            }
            SubTypeHair = subtypehair;
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
           ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id");
           ViewData["TypeHairId"] = new SelectList(_context.TypeHairs, "Id", "Id");
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

            _context.Attach(SubTypeHair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubTypeHairExists(SubTypeHair.ColorId))
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

        private bool SubTypeHairExists(Guid id)
        {
            return _context.SubTypeHairs.Any(e => e.ColorId == id);
        }
    }
}
