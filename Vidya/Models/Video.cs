using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidya.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int NumberInStock { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
    }
}