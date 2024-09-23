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
    public class IndexModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public IndexModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        public IList<CategoryThickness> CategoryThickness { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CategoryThickness = await _context.CategoryThickness
                .Include(c => c.Category)
                .Include(c => c.Thickness).ToListAsync();
        }
    }
}
