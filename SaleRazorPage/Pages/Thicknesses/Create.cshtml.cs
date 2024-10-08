﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SaleRazorPage.Model;
using SaleRazorPage.Utils;

namespace SaleRazorPage.Pages.Thicknesses
{
    public class CreateModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public CreateModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Thickness Thickness { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Thickness.NameUnAccent = RemoveAccent.RemoveDiacritics(Thickness.Name);

            _context.Thickness.Add(Thickness);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create");
        }
    }
}
