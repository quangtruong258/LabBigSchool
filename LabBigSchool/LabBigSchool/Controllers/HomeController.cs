using LabBigSchool.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using LabBigSchool.ViewModel;

namespace LabBigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbcontext;
        public HomeController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var comingCourse = _dbcontext.Courses.Include(c => c.Lecturer).Include(c => c.category).
                Where(c => c.datetime > DateTime.Now);
           
            var viewmodel = new CoursesViewModel
            {
                UpcomingCourse = comingCourse,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewmodel);


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}