using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab10v2.Models;
using Lab10v2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.IO;
using System;

namespace Lab10v2.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ShopController(MyDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        //[Route("Shop/GetCategory/{categoryName}")]
        public ActionResult Index(Result categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                    categoryViewModel.Categories = _context.Categories.ToList().Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();

                    var articlesFromCategory = _context.Articles.ToList().FindAll(x => x.CategoryId == categoryViewModel.SelectedCategoryId);
                    categoryViewModel.articles = articlesFromCategory;
                
            }
            return View(categoryViewModel);
        }

        







        // GET: ShopController
        //public ActionResult Index()
        //{
        //    ViewData["CategoryName"] = new SelectList(_context.Categories.Select(c => c.Name), "Name");
        //    return View("Views/Shop/Index.cshtml");
        //}

        //[Route("Shop/GetCategory/{categoryName}")]
        //public IActionResult GetCategory(string categoryName)
        //{
        //    var articles = _context.Articles
        //        .Where(a => a.Category.Name == categoryName)
        //        .Select(a =>
        //            new Article()
        //            {
        //                Id = a.Id,
        //                Name = a.Name,
        //                Price = a.Price,
        //                CategoryId = a.CategoryId,
        //                FilePath = a.FilePath,
        //            }
        //            )
        //        .ToList();



        //    return PartialView("Views/Shop/Table.cshtml", articles);
        //}




    }
}
