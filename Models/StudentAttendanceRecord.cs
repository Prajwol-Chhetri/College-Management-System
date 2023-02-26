using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class StudentAttendanceRecord
    {
        public int AttendanceID { get; set; }
        public string Status { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int StudentID { get; set; }
        public int DepartmentID { get; set; }
    }
}