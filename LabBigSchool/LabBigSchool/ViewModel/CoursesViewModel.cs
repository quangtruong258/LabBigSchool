using LabBigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabBigSchool.ViewModel
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcomingCourse { get; set; }
        public bool ShowAction { get; set; }
    }
}