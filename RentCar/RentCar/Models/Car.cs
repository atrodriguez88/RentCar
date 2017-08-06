using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Brand { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]        
        public decimal Miles { get; set; }
    }
}