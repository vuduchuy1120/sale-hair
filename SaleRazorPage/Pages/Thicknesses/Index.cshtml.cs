using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.Thicknesses
{
    public class IndexModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public IndexModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        public IList<Thickness> Thickness { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Thickness = await _context.Thickness.ToListAsync();
        }
    }
}
