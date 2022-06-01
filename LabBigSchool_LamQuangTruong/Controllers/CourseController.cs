using LabBigSchool_LamQuangTruong.Models;
using LabBigSchool_LamQuangTruong.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabBigSchool_LamQuangTruong.Controllers
{


    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        // GET: Course

        public CourseController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbcontext.Categorys.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbcontext.Categorys.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerID = User.Identity.GetUserId(),
                datetime = viewModel.getDateTime(),
                categoryID = viewModel.Category,
                Place = viewModel.Place
            };
            _dbcontext.Courses.Add(course);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}