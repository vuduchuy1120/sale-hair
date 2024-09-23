using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.SetHairRequests
{
    public class DeleteModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public DeleteModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SetHairRequest SetHairRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sethairrequest = await _context.HairRequests.FirstOrDefaultAsync(m => m.Id == id);

            if (sethairrequest == null)
            {
                return NotFound();
            }
            else
            {
                SetHairRequest = sethairrequest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sethairrequest = await _context.HairRequests.FindAsync(id);
            if (sethairrequest != null)
            {
                SetHairRequest = sethairrequest;
                _context.HairRequests.Remove(SetHairRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
