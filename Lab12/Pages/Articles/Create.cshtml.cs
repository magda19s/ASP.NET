using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab12.Data;
using Lab12.Models;
using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Lab12.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly Lab12.Data.MyDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private const string NOIMAGE = "/images/noPhoto.jpg";

        public CreateModel(Lab12.Data.MyDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;

        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Article article { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string newFileName = NOIMAGE;
                bool ifNewPhoto = false;
                if (article.Image != null)
                {

                    string uploadPath = Path.Combine(_hostEnvironment.WebRootPath, "upload");
                    newFileName = Guid.NewGuid().ToString() + "_" + article.Image.FileName;

                    var fileStream = new FileStream(Path.Combine(uploadPath, newFileName), FileMode.Create);
                    article.Image.CopyTo(fileStream);
                    fileStream.Close();
                    ifNewPhoto = true;


                }

                if (ifNewPhoto)
                {
                    newFileName = "/upload/" + newFileName;
                }

                article.FilePath = newFileName;



                _context.Add(article);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
