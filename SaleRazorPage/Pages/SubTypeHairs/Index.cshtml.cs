using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.SubTypeHairs
{
    public class IndexModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public IndexModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        public IList<SubTypeHair> SubTypeHair { get; set; } = default!;

        public async Task OnGetAsync()
        {
            SubTypeHair = await _context.SubTypeHairs
                .Include(s => s.Category)
                .Include(s => s.Color)
                .Include(s => s.TypeHair).ToListAsync();
        }
    }
}
