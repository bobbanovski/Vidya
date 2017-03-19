using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidya.Models;

namespace Vidya.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }
        
        [Min18YearsValidate]
        public DateTime? BirthDate { get; set; }
        
        public byte MembershipTypeId { get; set; } //foreign key
    }
}