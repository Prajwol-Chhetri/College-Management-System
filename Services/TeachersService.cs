using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollegeManagementSystem.Models;
using Oracle.ManagedDataAccess.Client;


namespace CollegeManagementSystem.Services
{
    public class TeachersService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CMS;PASSWORD=123;";

        // method to Add Teachers in database
        public void AddTeachers(TeacherViewModel teacher)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;

                        // first inserting data into person table to create a person
                        command.CommandText = String.Format("INSERT INTO person (name, email, gender, phone) " +
                            "VALUES ('{0}','{1}','{2}',{3})",
                            teacher.Name,
                            teacher.Email,
                            teacher.Gender,
                            teacher.Phone);
                        command.ExecuteNonQuery();

                        // getting the person id from table
                        command.CommandText = String.Format("SELECT person_id FROM person WHERE email = '{0}'", teacher.Email);
                        OracleDataReader dataReader = command.ExecuteReader();

                        // creating teacher profile after person is created
                        while (dataReader.Read())
                        {
                            command.CommandText = String.Format("INSERT INTO teacher (person_id) VALUES ({0})", Convert.ToInt32(dataReader["person_id"]));
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // method to delete teacher from database
        public void DeleteTeacher(int id)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("DELETE from person WHERE person_id = " + id); ;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to update data in teacher table
        public void EditTeacher(TeacherViewModel teacher)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("UPDATE person SET name = '{1}', email = '{2}', gender = '{3}', phone = {4} WHERE person_id = {0}",
                            teacher.PersonID,
                            teacher.Name,
                            teacher.Email,
                            teacher.Gender,
                            teacher.Phone);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to get all data in teacher table
        public IEnumerable<TeacherViewModel> GetAllTeacher()
        {
            List<TeacherViewModel> teachers = new List<TeacherViewModel>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT person_id, name, email, gender, phone, teacher_id FROM TEACHER NATURAL JOIN PERSON";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TeacherViewModel teacher = new TeacherViewModel
                        {
                            TeacherID = Convert.ToInt32(dataReader["teacher_id"]),
                            PersonID = Convert.ToInt32(dataReader["person_id"]),
                            Name = dataReader["name"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Gender = dataReader["gender"].ToString(),
                            Phone = Int64.Parse(dataReader["phone"].ToString())
                        };
                        teachers.Add(teacher);
                    }
                }
            }
            return teachers;
        }

        public TeacherViewModel GetTeacherById(int id)
        {
            TeacherViewModel teacher = new TeacherViewModel();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "SELECT person_id, name, email, gender, phone, teacher_id FROM PERSON NATURAL JOIN TEACHER WHERE person_id = " + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        teacher.PersonID = Convert.ToInt32(rdr["person_id"]);
                        teacher.TeacherID = Convert.ToInt32(rdr["teacher_id"]);
                        teacher.Name = rdr["name"].ToString();
                        teacher.Email = rdr["email"].ToString();
                        teacher.Gender = rdr["gender"].ToString();
                        teacher.Phone = Int64.Parse(rdr["phone"].ToString());
                    }
                }
            }
            return teacher;
        }
    }
}