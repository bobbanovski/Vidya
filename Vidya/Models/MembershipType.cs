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

        public static readonly byte Unknown = 0; //using elsewhere causes compilation err
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quarterly = 3;
        public static readonly byte Annual = 4;
    }
}