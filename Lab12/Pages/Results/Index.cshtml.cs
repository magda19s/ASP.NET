using Lab12.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Pages.Results
{
    public class IndexModel : PageModel
    {
        private readonly Lab12.Data.MyDbContext _context;

        public IndexModel(Lab12.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public int id { get; set; }

        public async Task OnGetAsync(int? id)
        {
            
                Article = await _context.Articles
                    .Include(a => a.Category).ToListAsync();

                Categories = _context.Categories.ToList().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                Article = _context.Articles.ToList().FindAll(x => x.CategoryId == id);
            

        }

    }
}
