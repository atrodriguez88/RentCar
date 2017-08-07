using RentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.ViewModel
{
    public class CustomersFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}