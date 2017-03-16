using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidya.Models
{
    public class Genre
    {
        public byte Id { get; set; } //this must be same data type as foreign key

        [Required] 
        [StringLength(255)] 
        public string Name { get; set; }
    }
}