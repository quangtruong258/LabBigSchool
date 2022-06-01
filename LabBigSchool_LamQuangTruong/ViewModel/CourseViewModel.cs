﻿using LabBigSchool_LamQuangTruong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabBigSchool_LamQuangTruong.ViewModel
{
    public class CourseViewModel
    {
        //
        [Required]
        public string Place { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public DateTime getDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1},", Date, Time));
        }
    }
}