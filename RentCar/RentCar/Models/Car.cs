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

        public Brand Brand { get; set; }

        [Display(Name ="Brand")]
        public byte Brand_Id { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]        
        public decimal Miles { get; set; }
        [Required]
        public short Stock { get; set; }
        public short NumberAvailable { get; set; }
    }
}