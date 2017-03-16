using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidya.Models;

namespace Vidya.Controllers
{
    public class VideoController : Controller
    {
        private ApplicationDbContext _context;

        public VideoController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var videos = _context.Videos.ToList();
            return View(videos);
        }

        public ActionResult Details(int id)
        {
            var video = _context.Videos.FirstOrDefault(x => x.Id == id);
            return View(video);
        }
    }
}