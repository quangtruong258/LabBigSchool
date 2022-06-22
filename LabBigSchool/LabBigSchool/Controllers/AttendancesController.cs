using LabBigSchool.DTOs;
using LabBigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabBigSchool.Controllers
{
   

    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO attendanceDTO)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a =>a.AttendeeId == userId && a.CourseId == attendanceDTO.CourseId))
            {
                return BadRequest("The Attendance is already exists");
            }
            var att = new Attendance
            {
                CourseId = attendanceDTO.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(att);
            _dbContext.SaveChanges();
            return Ok();
        }
      
    }
}
