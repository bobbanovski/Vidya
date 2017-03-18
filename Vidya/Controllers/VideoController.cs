using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidya.Models;
using Vidya.ViewModels;

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
            var videos = _context.Videos.Include(v => v.Genre).ToList();
            return View(videos);
        }

        public ActionResult EditVideo(int id)
        {
            var video = _context.Videos.FirstOrDefault(x => x.Id == id);
            if (video == null)
                return HttpNotFound();

            var viewModel = new VideoFormView
            {
                Video = video,
                Genres = _context.Genres.ToList()
            };
            return View("VideoForm", viewModel);
        }

        public ActionResult NewVideo()
        {
            var videoView = new VideoFormView
            {
                Video = new Video(),
                Genres = _context.Genres.ToList()
            };
            return View("VideoForm", videoView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Video video)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VideoFormView
                {
                    Video = new Video(),
                    Genres = _context.Genres.ToList()
                };
                return View("VideoForm", viewModel);
            }
            if (video.Id == 0)
                _context.Videos.Add(video);
            else
            {
                var getVideo = _context.Videos.Single(v => v.Id == video.Id);
                getVideo.Name = video.Name;
                getVideo.DateAdded = video.DateAdded;
                getVideo.ReleaseDate = video.ReleaseDate;
                getVideo.NumberInStock = video.NumberInStock;
                getVideo.GenreId = video.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Video");
        }
    }
}