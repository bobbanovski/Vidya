﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidya.Models;

namespace Vidya.ViewModels
{
    public class NewCustomerView
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}