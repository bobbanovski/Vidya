using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidya.Models
{
    public class Min18YearsValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo) //use readonly here to remove magic string
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birth date is required");
            //Check customer age
            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            if (age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer must be over the age of 18 for this membership");
        }
    }
}