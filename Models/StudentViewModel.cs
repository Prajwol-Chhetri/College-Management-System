using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CollegeManagementSystem.Models
{
    public class StudentViewModel
    {
        [Key]
        public int PersonID { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
    }
}