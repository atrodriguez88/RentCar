﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class Customer
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

        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membreship Type")]
        public byte MembershipType_Id { get; set; }
    }
}