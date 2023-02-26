using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class StudentFeeRecord
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public int StudentID { get; set; }
        public int PaymentID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DateOfPayment { get; set; }
        public int SemesterFeeID { get; set; }
        public string SemesterName { get; set; }    
        public decimal Fee { get; set; }
        public int DepartmentID { get; set; }
    }
}