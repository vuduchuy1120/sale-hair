﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.Thornes
{
    public class EditModel : PageModel
    {
        private readonly SaleRazorPage.Model.AppDbContext _context;

        public EditModel(SaleRazorPage.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Thorne Thorne { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thorne =  await _context.Thornes.FirstOrDefaultAsync(m => m.Id == id);
            if (thorne == null)
            {
                return NotFound();
            }
            Thorne = thorne;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Thorne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThorneExists(Thorne.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ThorneExists(Guid id)
        {
            return _context.Thornes.Any(e => e.Id == id);
        }
    }
}
