using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class Examination
    {
        public int ExamID { get; set; }
        public int ModuleID { get; set; }
        public int AssignmentID { get; set; }
        public int DepartmentID { get; set; }
    }
}