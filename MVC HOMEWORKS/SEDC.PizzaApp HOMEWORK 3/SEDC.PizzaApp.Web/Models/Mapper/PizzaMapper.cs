using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models.Mapper
{
    public static class PizzaMapper
    {
        public static PizzaViewModel PizzaToPizzaViewModel(Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                IsOnPromotion = pizza.IsOnPromotion
            };
        }
    }
}
