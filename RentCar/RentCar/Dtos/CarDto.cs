using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }

        public byte Brand_Id { get; set; }

        public BrandDto BrandDto { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public decimal Miles { get; set; }
        [Required]
        public short Stock { get; set; }
    }
}