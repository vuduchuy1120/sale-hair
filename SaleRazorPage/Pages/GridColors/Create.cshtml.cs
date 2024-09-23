using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using SaleRazorPage.Model;
using SaleRazorPage.Utils;

namespace SaleRazorPage.Pages.GridColors
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


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GridColor GridColor { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageUpload { get; set; }  // Thuộc tính file ảnh
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
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
                    var imagesFolder = Path.Combine(_environment.WebRootPath, "images/gird-colors");
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

                    // Lưu đường dẫn file vào thuộc tính Image của Color
                    GridColor.Image = "/images/gird-colors/" + fileName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"File upload failed: {ex.Message}");
                    return Page();
                }
            }

            GridColor.NameUnAccent = RemoveAccent.RemoveDiacritics(GridColor.Name);


            _context.GridColors.Add(GridColor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
