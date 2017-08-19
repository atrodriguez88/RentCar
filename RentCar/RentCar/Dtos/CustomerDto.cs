using RentCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }

        public byte MembershipType_Id { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}