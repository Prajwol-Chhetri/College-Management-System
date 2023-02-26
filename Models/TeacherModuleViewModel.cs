using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CollegeManagementSystem.Models
{
    public class TeacherModuleViewModel
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public int TeacherID { get; set; }
        public int ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int CreditHours { get; set; }
    }
}