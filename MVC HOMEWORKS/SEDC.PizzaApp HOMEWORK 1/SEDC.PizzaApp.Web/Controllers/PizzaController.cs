using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    //[Route("pizzas")]
    public class PizzaController : Controller
    {
        //[Route("pizza-list")]
        public IActionResult Index()
        {
            List<Pizza> pizzas = StaticDB.Pizzas;
            return new JsonResult(pizzas);
        }

        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                Pizza pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == id);

                if (pizza == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                return View("~/Views/Pizza/PizzaDetails.cshtml");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
