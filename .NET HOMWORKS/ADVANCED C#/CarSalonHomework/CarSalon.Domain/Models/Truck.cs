using System;
using System.Collections.Generic;
using System.Text;
using CarSalon.Domain.Enums;

namespace CarSalon.Domain.Models
{
    public class Truck : BaseVehicle
    {
        public CarBrands Brand { get; set; }
        public int FinalPrice { get; set; } 

        public Func<int> finalPriceCalc = (this BasePrice)
}
