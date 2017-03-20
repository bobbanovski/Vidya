using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidya.Dtos
{
    public class VideoDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(1, 20)]
        [Required]
        public int NumberInStock { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
    }
}