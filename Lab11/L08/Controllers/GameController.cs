using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace L08.Controllers
{
    public class GameController : Controller
    {
        
        // GET: GameController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameController/Create
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

        // GET: GameController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameController/Edit/5
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

        // GET: GameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameController/Delete/5
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





        public IActionResult Set(int valZakres)
        {
            
            if (valZakres > 0)
            {
                HttpContext.Session.SetInt32("range", valZakres);
                ViewBag.zakres = $"Ustawiono zakres: 0 - {valZakres}";
            }
            else
            {
                ViewBag.zakres = "Wrong range!";
            }


            return View("Set");
        }

        public IActionResult Draw()
        {
            Random rnd = new Random();
            int zakres = 0;
            ViewBag.info = "Musisz ustawić zakres";


            if (HttpContext.Session.GetInt32("range") > 0)
            {
                zakres = (int)HttpContext.Session.GetInt32("range");
                ViewBag.info = $"ZAKRES 0 - {zakres}";
                
            } else
            {
                ViewBag.info = "Musisz ustawić zakres";

            }

            if (zakres>0)
            {
                int choice = rnd.Next(0, zakres);
                int userTry = 0;
                HttpContext.Session.SetInt32("choice", choice);
                HttpContext.Session.SetInt32("userTry", userTry);
                ViewBag.info = ViewBag.info + "Wylosowano liczbę! Możesz zacząć grę.";

            } else
            {
                ViewBag.info = "Musisz ustawić PRAWIDŁOWY zakres";

            }


            return View("Draw");
        }

        public IActionResult Guess(int liczba)
        {

            int zakres = 0;
            int choice = 0;
            int userTry = 0;
            if ((HttpContext.Session.GetInt32("range") > 0)) {
                zakres = (int)(HttpContext.Session.GetInt32("range"));
                choice = (int)(HttpContext.Session.GetInt32("choice"));
                userTry = (int)(HttpContext.Session.GetInt32("userTry"));
            } else
            {
                ViewBag.info = "Musisz najpierw podać zakres!";
            }

            

            ViewBag.zakres = "Twoim zadaniem jest odgadnięcie liczby z zakresu 0-" + HttpContext.Session.GetInt32("range");
            

            

            if (liczba >= 0 && liczba < zakres)
            {
                if (liczba < choice)
                {
                    ViewBag.info = "Liczba jest mniejsza od wylosowanej";
                    userTry++;
                    ViewBag.proby = "Ilość prób: " + userTry;
                } else if (liczba > choice)
                {
                    ViewBag.info = "Liczba jest większa od wylosowanej";
                    userTry++;
                    ViewBag.proby = "Ilość prób: " + userTry;
                }
                else if (liczba == choice)
                {
                    ViewBag.info = "Brawo!";
                    userTry++;
                    ViewBag.proby = "Ilość prób: " + userTry;
                    

                }
            } else
            {
                ViewBag.info = "Musisz podać poprawny zakres!";
            }

            HttpContext.Session.SetInt32("userTry", userTry);



            return View("Guess");
        }




    }
}
