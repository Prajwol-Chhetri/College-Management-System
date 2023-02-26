using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Data
{
    public class CollegeManagementSystemContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CollegeManagementSystemContext() : base("name=CollegeManagementSystemContext")
        {
        }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.Module> Modules { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.TeacherViewModel> TeacherViewModels { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.StudentViewModel> StudentViewModels { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.TeacherModuleViewModel> TeacherModuleViewModels { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.StudentFeeRecord> StudentFeeRecords { get; set; }

        public System.Data.Entity.DbSet<CollegeManagementSystem.Models.StudentAssignment> StudentAssignments { get; set; }
    }
}
