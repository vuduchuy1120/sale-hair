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
    public class IndexModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public IndexModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        public IList<SetHairRequest> SetHairRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SetHairRequest = await _context.HairRequests
                .Include(s => s.Category).ToListAsync();
        }
    }
}
