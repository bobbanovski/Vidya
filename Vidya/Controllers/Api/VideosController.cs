using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidya.Dtos;
using Vidya.Models;

namespace Vidya.Controllers.Api
{
    public class VideosController : ApiController
    {
        private ApplicationDbContext _context;

        public VideosController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<VideoDto> GetVideos()
        {
            return _context.Videos.ToList().Select(Mapper.Map<Video, VideoDto>);
        }

        public IHttpActionResult GetVideo(int id)
        {
            var video = _context.Videos.SingleOrDefault(v => v.Id == id);
            if (video == null)
                return NotFound();
            return Ok(Mapper.Map<Video, VideoDto>(video));
        }

        [HttpPost]
        public IHttpActionResult NewVideo(VideoDto videoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var newVideo = Mapper.Map<VideoDto, Video>(videoDto);
            _context.Videos.Add(newVideo);
            _context.SaveChanges();
            videoDto.Id = newVideo.Id;
            return Created(new Uri(Request.RequestUri + "/" + newVideo.Id), videoDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateVideo(int id, VideoDto video)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var videoSelect = _context.Videos.FirstOrDefault(v => v.Id == id);
            if (videoSelect == null)
                return NotFound();
            Mapper.Map(video, videoSelect);
            _context.SaveChanges();
            return Ok(204);
        }

        [HttpDelete]
        public IHttpActionResult DeleteVideo(int id)
        {
            var videoSelect = _context.Videos.FirstOrDefault(v => v.Id == id);
            if (videoSelect == null)
                return NotFound();
            _context.Videos.Remove(videoSelect);
            return Ok(204);
        }
    }
}
