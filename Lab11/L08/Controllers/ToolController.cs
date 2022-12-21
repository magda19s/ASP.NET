using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace L08.Controllers
{
    public class ToolController : Controller
    {
        // GET: ToolController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ToolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToolController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Zadanie1()
        {
            ViewBag.Message = "Zadanie 1";
            ViewBag.ValueX = 1234;
            ViewBag.ValueText = "text value";
            return View();
        }

        public IActionResult Zadanie1a(int number, string name, string other)
        {
            ViewBag.Message = "Parametric page number=" + number + " name=" +
            name + " , other=" + other;
            return View("Zadanie1");
        }

        public IActionResult Solve(double a, double b, double c)
        {

            ViewBag.x1 = "";
            ViewBag.x2 = "";
            ViewBag.label = "";
            ViewBag.info = "";
            ViewBag.labelVal = "val";
            

            
            if (a == 0 && b == 0 && c == 0)
            {
                
                //ViewBag.x1 = double.PositiveInfinity;
                //ViewBag.x2 = double.PositiveInfinity;
                ViewBag.label = "tozsamo";
                ViewBag.info = "Równanie tożsamościowe";



            }
            else if (a == 0 && b == 0 && c != 0)
            {
                //ViewBag.x1 = null;
                //ViewBag.x2 = null;
                ViewBag.label = "error";
                ViewBag.info = "Równanie sprzeczne";


            } else if (a==0)
            {
               
                double x = -c / b;
                ViewBag.x1 = "x1 = " + Math.Round(x,4);
                ViewBag.x2 = null;
                ViewBag.label = "jedno";
                ViewBag.info = "Równanie ma jedno rozwiązanie";
            }
            else
            {


                double delta = b * b - 4 * a * c;
                if (delta > 0)
                {
                    double x11 = (-b - Math.Sqrt(delta)) / 2 * a;
                    ViewBag.x1 = "x1 = " + Math.Round(x11,4);
                    double x22 = (-b + Math.Sqrt(delta)) / 2 * a;
                    ViewBag.x2= "x2 = " + Math.Round(x22,4);
                    ViewBag.label = "two";
                    ViewBag.info = "Równanie ma dwa rozwiązania";





                }
                else if (delta == 0)
                {
                    double x11 = -b / 2 * a;
                    ViewBag.x1 = "x1 = " + Math.Round(x11, 4);
                    ViewBag.x2 = null;
                    ViewBag.label = "jedno";
                    ViewBag.info = "Równanie ma jedno rozwiązanie ";

                }


            }

            


            


            return View("Solve");

        }
    }
}
