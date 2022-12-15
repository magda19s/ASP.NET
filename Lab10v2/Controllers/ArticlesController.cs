using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab10v2.Data;
using Lab10v2.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Lab10v2.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private const string NOIMAGE = "/images/noPhoto.jpg";

        public ArticlesController(MyDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;

        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Articles.Include(a => a.Category);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        public static string GetImage(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return NOIMAGE;
            } else
            {
                return "/upload/" + path;
            }
        }

       

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId,Image")] Article article)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", article.CategoryId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", article.CategoryId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId,FilePath")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            } 

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", article.CategoryId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article.FilePath != null)
            {
                string articlePath = article.FilePath.Substring(8);
                string filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload", articlePath);
                var image = new FileInfo(filePath);


                if (image.Exists)
                {
                    image.Delete();
                }
            }
            
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
