using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidya.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int NumberInStock { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; } //foreign key //this must be same data type as foreign key
    }
}