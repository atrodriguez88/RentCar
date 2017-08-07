using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Version { get; set; }
    }
}