using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models;
using SEDC.PizzaApp.Web.Models.Mapper;
using SEDC.PizzaApp.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> pizzas = StaticDB.Pizzas;
            List<PizzaViewModel> pizzaMenu = new List<PizzaViewModel>();

            foreach (Pizza pizza in pizzas)
            {
                pizzaMenu.Add(PizzaMapper.PizzaToPizzaViewModel(pizza));
            }

            ViewData.Add("PizzaListTitle", "Pizza List");
            return View(pizzaMenu);
        }
        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                Pizza foundPizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == id);


                if (foundPizza == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                PizzaViewModel pizza = PizzaMapper.PizzaToPizzaViewModel(foundPizza);
                ViewBag.Pizza = pizza;
                ViewData.Add("PizzaDetailsTitle", "Pizza Details Page");
                return View("~/Views/Pizza/PizzaDetails.cshtml");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
