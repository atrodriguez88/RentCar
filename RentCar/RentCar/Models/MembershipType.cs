using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public short SignUpFee { get; set; }    //Dollars
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}