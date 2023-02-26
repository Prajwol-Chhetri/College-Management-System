using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class StudentAssignment
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string AssignmentType { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
    }
}