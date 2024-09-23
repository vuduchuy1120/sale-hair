using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public Guid CategoryId { get; set; }
        [BindProperty]
        public Guid TypeHairId { get; set; }
        [BindProperty]
        public Guid ColorId { get; set; }
        [BindProperty]
        public int Option { get; set; }
        [BindProperty]
        public string Search { get; set; }
        [BindProperty]
        public bool showAlert { get; set; }
        [BindProperty]
        public string alertMessage { get; set; }

        public IList<Category> Categories { get; set; }
        public IList<TypeHair> TypeHairs { get; set; }
        public IList<Color> Colors { get; set; }
        public void OnGet()
        {
            Categories = _context.Categories.ToList();
            ViewData["CategoryId"] = new SelectList(Categories, "Id", "Name");

            TypeHairs = _context.TypeHairs.ToList();
            ViewData["TypeHairId"] = new SelectList(TypeHairs, "Id", "Name");

            Colors = _context.Colors.ToList();
            ViewData["ColorId"] = new SelectList(Colors, "Id", "Name");
        }
    }
}
