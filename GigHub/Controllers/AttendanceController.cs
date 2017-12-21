using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendanceController : ApiController
    {
        private readonly ApplicationDbContext _Context;
        public AttendanceController()
        {
            _Context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendansDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_Context.Attendences.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
                return BadRequest("The attendance already exist");

            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = User.Identity.GetUserId()
            };
            _Context.Attendences.Add(attendance);
            _Context.SaveChanges();

            return Ok();
        }
    }
}
