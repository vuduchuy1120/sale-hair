using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public int CategoryId { get; set; }

        [BindProperty]
        public int Option { get; set; }
        [BindProperty]
        public string Search { get; set; }
        [BindProperty]
        public bool showAlert { get; set; }
        [BindProperty]
        public string alertMessage { get; set; }

        public IList<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }
    }
}
