using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Car Car { get; set; }
        
        [Required]
        public Customer Customer { get; set; }

        public DateTime RentalDate { get; set; }
        public DateTime? RentalReturn { get; set; }
    }
}