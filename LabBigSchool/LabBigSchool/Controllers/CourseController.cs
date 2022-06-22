using LabBigSchool.Models;
using LabBigSchool.ViewModel;
//using LabBigSchool.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                Categories = _dbcontext.Categorys.ToList(),
                Heading = "Add Course"
            };
            return View("CoursesForm",viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                datetime = viewModel.GetDateTime(),
                categoryID = viewModel.Category,
                Place = viewModel.Place
            };
            _dbcontext.Courses.Add(course);
            _dbcontext.SaveChanges();

            return RedirectToAction("CoursesForm", "Course");
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lecturer)
                .Include(l => l.category)
                .ToList();
            var viewModel = new CoursesViewModel
            {
                UpcomingCourse = courses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Courses
                .Where(a => a.LecturerID == userId && a.datetime> DateTime.Now)
                .Include(l => l.Lecturer)
                .Include(l => l.category)
                .ToList();            
            return View(courses);
        }


        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Courses
                .Single(a => a.ID == id && a.LecturerID == userId);
            var viewModel = new CourseViewModel
            {
                Categories = _dbcontext.Categorys.ToList(),
                Date = courses.datetime.ToString("dd/M/yyyy"),
                Time = courses.datetime.ToString("HH:mm"),
                Category = courses.categoryID,
                Place = courses.Place,
                Heading = "Edit Course",
                Id = courses.ID
            };
            return View("CoursesForm", viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                courseViewModel.Categories = _dbcontext.Categorys.ToList();
                return View("Create", courseViewModel);
            }
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Courses
                .Single(a => a.ID == courseViewModel.Id && a.LecturerID == userId);
            courses.Place = courseViewModel.Place;
            courses.datetime = courseViewModel.GetDateTime();
            courses.categoryID = courseViewModel.Category;
            _dbcontext.SaveChanges();

            return RedirectToAction("CoursesForm", "Course");

        }
    }
}