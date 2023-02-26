using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public int PersonID { get; set; }
    }
}