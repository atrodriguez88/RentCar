using RentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.ViewModel
{
    public class CarFormViewModel
    {
        public IEnumerable<Brand> Brands { get; set; }

        public Car Car { get; set; }
    }
}