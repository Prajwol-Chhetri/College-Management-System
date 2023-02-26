using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class StudentResult
    {
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public string Grade { get; set; }
        public int DepartmentID { get; set; }
    }
}