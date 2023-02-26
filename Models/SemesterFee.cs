using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class SemesterFee
    {
        public int SemesterFeeID { get; set; }
        public decimal Fee { get; set; }
        public int CourseID { get; set; }
        public int SemesterID { get; set; }
    }
}