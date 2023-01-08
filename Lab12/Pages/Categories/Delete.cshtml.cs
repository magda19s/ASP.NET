using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab12.Data;
using Lab12.Models;

namespace Lab12.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly Lab12.Data.MyDbContext _context;

        public DeleteModel(Lab12.Data.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FindAsync(id);
            var count = _context.Articles.Count(a => a.CategoryId == id);
            if (count > 0)
            {
                ViewData["tryDelete"] = true;
                return Page();
            } 

            if (Category != null)
            {
               

                    _context.Categories.Remove(Category);
                    await _context.SaveChangesAsync();
                
            }

            return RedirectToPage("./Index");
        }
    }
}
