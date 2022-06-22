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
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IHttpActionResult Follow(FollowingDTO followingDTO)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == followingDTO.FolloweeId))
            {
                return BadRequest("Following already exists");
            }
            var follow = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDTO.FolloweeId
            };
            _dbContext.Followings.Add(follow);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
