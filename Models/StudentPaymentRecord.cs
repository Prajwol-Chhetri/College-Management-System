using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class StudentPaymentRecord
    {
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfPayment { get; set; }
        public int StudentID { get; set; }
        public int SemesterFeeID { get; set; }
        public int DepartmentID { get; set; }
    }
}