using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using SaleRazorPage.Model;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SaleRazorPage.Utils;

namespace SaleRazorPage.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(SaleRazorPage.Model.AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageUpload { get; set; }  // Thuộc tính file ảnh

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Xử lý lưu file ảnh
            if (ImageUpload != null)
            {
                var supportedTypes = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExt = Path.GetExtension(ImageUpload.FileName).ToLower();

                // Kiểm tra xem định dạng file có hợp lệ không
                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError(string.Empty, "Invalid file type. Only the following types are supported: .jpg, .jpeg, .png, .gif");
                    return Page();
                }

                try
                {
                    // Đảm bảo thư mục 'wwwroot/images' tồn tại
                    var imagesFolder = Path.Combine(_environment.WebRootPath, "images");
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    var fileName = Path.GetFileName(ImageUpload.FileName);
                    var filePath = Path.Combine(imagesFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageUpload.CopyToAsync(stream);
                    }

                    // Lưu đường dẫn file vào thuộc tính Image của Category
                    Category.Image = "/images/" + fileName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"File upload failed: {ex.Message}");
                    return Page();
                }
            }

            Category.NameUnAccent = RemoveAccent.RemoveDiacritics(Category.Name);
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
