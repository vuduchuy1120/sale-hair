using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.LengthThicknessPrices
{
    public class IndexModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public IndexModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        public IList<LengThicknessPrice> LengThicknessPrice { get; set; } = default!;

        public async Task OnGetAsync()
        {
            LengThicknessPrice = await _context.LengThicknessPrice
                .Include(l => l.Length)
                .Include(l => l.Thickness).ToListAsync();
        }
    }
}
