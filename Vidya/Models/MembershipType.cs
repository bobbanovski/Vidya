using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidya.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignupFee { get; set; }
        public byte DurationMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string MembershipName { get; set; }
    }
}