using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab10v2.Data;
using Lab10v2.Models;
using Microsoft.AspNetCore.Http;

namespace Lab10v2.Controllers
{
    public class ShopCartsController : Controller
    {
        private readonly MyDbContext _context;
        CookieOptions options;
        Dictionary<int, Article> _articles; 


        public ShopCartsController(MyDbContext context)
        {
            _context = context;
            _articles = new Dictionary<int, Article>();
            options = new CookieOptions();
        }

        // GET: ShopCarts
        public async Task<IActionResult> Index()
        {
            var cookies = Request.Cookies.Keys;
            if (cookies.Count == 0)
            {
                return View();
            }

            var products = new List<ShopCart>();

            foreach (var cookie in cookies)
            {
                List<Article> articles;
                
                int artId;

                if (Int32.TryParse(cookie, out artId))
                {
                    articles = _context.Articles.Where(a => a.Id == artId).ToList();


                    if (articles.Count() == 0)
                    {
                        TempData["Message"] = "Some products in your shopping cart are no longer available";
                        Response.Cookies.Delete(cookie);
                    }
                    else
                    {
                        int amount = Int32.Parse(Request.Cookies[cookie]);
                        ShopCart productsCart = new ShopCart()
                        {
                            Id = articles[0].Id,
                            Name = articles[0].Name,
                            TotalPrice = Math.Round(amount * articles[0].Price, 4),
                            Category = _context.Categories.Where(a => a.Id == articles[0].CategoryId).FirstOrDefault(),
                            Image = articles[0].FilePath,
                            Amount = amount
                        };
                        products.Add(productsCart);
                    }
                }
                
            }


            return View(products);
        }

        


        public async Task<IActionResult> Increase(int id)
        {
            string myAmount = Request.Cookies[id.ToString()];
            options.Expires = DateTime.Now.AddDays(7);
            int value = Int32.Parse(myAmount) + 1;
            Response.Cookies.Append(id.ToString(), value.ToString(), options);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Decrease(int id)
        {
            string myAmount = Request.Cookies[id.ToString()];
            int newAmount = Int32.Parse(myAmount) - 1;

            if (newAmount == 0)
            {
                Response.Cookies.Delete(id.ToString());
            }
            else
            {
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append(id.ToString(), newAmount.ToString(), options);
            }
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            Response.Cookies.Delete(id.ToString());
            return RedirectToAction("Index");

        }

        public IActionResult BuyArticle(int id)
        {
            options.Expires = DateTime.Now.AddDays(7);
            string idOfIthem = id.ToString();
            string myAmount = Request.Cookies[idOfIthem];
            if (myAmount == null || myAmount == " ")
            {
                Response.Cookies.Append(id.ToString(), "1", options);
            }
            else
            {
                int value = Int32.Parse(myAmount) + 1;
                Response.Cookies.Append(id.ToString(), value.ToString(), options);
            }
            return RedirectToAction("Index");
        }



    }
}
