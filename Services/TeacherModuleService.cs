using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using CollegeManagementSystem.Models;



namespace CollegeManagementSystem.Services
{
    public class TeacherModuleService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CMS;PASSWORD=123;";

        // function to get all data of teacher module mapping table
        public IEnumerable<TeacherModuleViewModel> GetAllTeacherModule()
        {
            List<TeacherModuleViewModel> teacherModules = new List<TeacherModuleViewModel>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = @"SELECT person_id, name, email, gender, phone, teacher_id, module_id, module_code, module_name, credit_hours 
                        FROM PERSON 
                        NATURAL JOIN TEACHER 
                        NATURAL JOIN TEACHER_MODULE 
                        NATURAL JOIN MODULE";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TeacherModuleViewModel teacherModule = new TeacherModuleViewModel
                        {
                            PersonID = Convert.ToInt32(dataReader["person_id"]),
                            Name = dataReader["name"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Gender = dataReader["gender"].ToString(),
                            Phone = Int64.Parse(dataReader["phone"].ToString()),
                            TeacherID = Convert.ToInt32(dataReader["teacher_id"]),
                            ModuleID = Convert.ToInt32(dataReader["module_id"]),
                            ModuleCode = dataReader["module_code"].ToString(),
                            ModuleName = dataReader["module_name"].ToString(),
                            CreditHours = Convert.ToInt32(dataReader["credit_hours"])
                        };
                        teacherModules.Add(teacherModule);
                    }
                }
            }
            return teacherModules;
        }

        public TeacherModuleViewModel GetTeacherModuleById(int id)
        {
            TeacherModuleViewModel teacherModule = new TeacherModuleViewModel();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = @"SELECT person_id, name, email, gender, phone, teacher_id, module_id, module_code, module_name, credit_hours 
                        FROM PERSON 
                        NATURAL JOIN TEACHER 
                        NATURAL JOIN TEACHER_MODULE 
                        NATURAL JOIN MODULE
                        WHERE person_id = " + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        teacherModule.PersonID = Convert.ToInt32(rdr["person_id"]);
                        teacherModule.Name = rdr["name"].ToString();
                        teacherModule.Email = rdr["email"].ToString();
                        teacherModule.Gender = rdr["gender"].ToString();
                        teacherModule.Phone = Int64.Parse(rdr["phone"].ToString());
                        teacherModule.TeacherID = Convert.ToInt32(rdr["teacher_id"]);
                        teacherModule.ModuleID = Convert.ToInt32(rdr["module_id"]);
                        teacherModule.ModuleCode = rdr["module_code"].ToString();
                        teacherModule.ModuleName = rdr["module_name"].ToString();
                        teacherModule.CreditHours = Convert.ToInt32(rdr["credit_hours"]);
                    }
                }
                return teacherModule;
            }
        }
    }
}