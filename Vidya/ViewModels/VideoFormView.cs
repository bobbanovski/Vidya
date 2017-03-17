using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidya.Models;

namespace Vidya.ViewModels
{
    public class VideoFormView
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Video Video { get; set; }
    }
}