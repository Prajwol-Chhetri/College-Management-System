using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using CollegeManagementSystem.Models;


namespace CollegeManagementSystem.Services
{
    public class StudentsService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CMS;PASSWORD=123;";

        // method to Add Students in database
        public void AddStudents(StudentViewModel student)
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
                            student.Name,
                            student.Email,
                            student.Gender,
                            student.Phone);
                        command.ExecuteNonQuery();

                        // getting the person id from table
                        command.CommandText = String.Format("SELECT person_id FROM person WHERE email = '{0}'", student.Email);
                        OracleDataReader dataReader = command.ExecuteReader();

                        // creating student profile after person is created
                        while (dataReader.Read())
                        {
                            command.CommandText = String.Format("INSERT INTO student (person_id) VALUES ({0})", Convert.ToInt32(dataReader["person_id"]));
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


        // method to delete student from database
        public void DeleteStudent(int id)
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


        // function to update data in student table
        public void EditStudent(StudentViewModel student)
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
                            student.PersonID,
                            student.Name,
                            student.Email,
                            student.Gender,
                            student.Phone);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to get all data in student table
        public IEnumerable<StudentViewModel> GetAllStudent()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT person_id, name, email, gender, phone, student_id FROM STUDENT NATURAL JOIN PERSON";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        StudentViewModel student = new StudentViewModel
                        {
                            StudentID = Convert.ToInt32(dataReader["student_id"]),
                            PersonID = Convert.ToInt32(dataReader["person_id"]),
                            Name = dataReader["name"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Gender = dataReader["gender"].ToString(),
                            Phone = Int64.Parse(dataReader["phone"].ToString())
                        };
                        students.Add(student);
                    }
                }
            }
            return students;
        }

        public StudentViewModel GetStudentById(int id)
        {
            StudentViewModel student = new StudentViewModel();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "SELECT person_id, name, email, gender, phone, student_id FROM PERSON NATURAL JOIN STUDENT WHERE person_id = " + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        student.PersonID = Convert.ToInt32(rdr["person_id"]);
                        student.StudentID = Convert.ToInt32(rdr["student_id"]);
                        student.Name = rdr["name"].ToString();
                        student.Email = rdr["email"].ToString();
                        student.Gender = rdr["gender"].ToString();
                        student.Phone = Int64.Parse(rdr["phone"].ToString());
                    }
                }
            }
            return student;
        }
    }
}