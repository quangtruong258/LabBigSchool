﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabBigSchool.Models
{
    public class Course
    {
        public int ID { get; set; }
        public ApplicationUser Lecturer { get; set; }
        [Required]
        public string LecturerID { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime datetime { get; set; }
        public Category category { get; set; }
        [Required]
        public byte categoryID { get; set; }
    }
}