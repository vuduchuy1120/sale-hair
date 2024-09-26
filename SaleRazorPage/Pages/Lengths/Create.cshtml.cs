using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.Lengths
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
            return Page();
        }

        [BindProperty]
        public Length Length { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Lengths.Add(Length);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
