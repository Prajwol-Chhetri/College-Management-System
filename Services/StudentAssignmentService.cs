using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using CollegeManagementSystem.Models;


namespace CollegeManagementSystem.Services
{
    public class StudentAssignmentService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CMS;PASSWORD=123;";

        // function to get all data of student assignment record mapping table
        public IEnumerable<StudentAssignment> GetAllStudentAssignment()
        {
            List<StudentAssignment> studentAssignments = new List<StudentAssignment>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = @"SELECT s.student_id, p.name, a.assignment_type, m.module_code, m.module_name, g.grade, g.status
                        FROM student_result r
                            INNER JOIN student s
                            ON r.student_id = s.student_id
                            INNER JOIN person p
                            ON p.person_id = s.person_id
                            INNER JOIN examination e
                            ON r.exam_id = e.exam_id
                            INNER JOIN module m
                            ON e.module_id = m.module_id
                            INNER JOIN assignment a
                            ON e.assignment_id = a.assignment_id
                            INNER JOIN grade g
                            ON r.grade = g.grade";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        StudentAssignment studentAssignment = new StudentAssignment
                        {
                            StudentID = Convert.ToInt32(dataReader["student_id"]),
                            Name = dataReader["name"].ToString(),
                            AssignmentType = dataReader["assignment_type"].ToString(),
                            ModuleCode = dataReader["module_Code"].ToString(),
                            ModuleName = dataReader["module_name"].ToString(),
                            Grade = dataReader["grade"].ToString(),
                            Status = dataReader["status"].ToString()
                        };
                        studentAssignments.Add(studentAssignment);
                    }
                }
            }
            return studentAssignments;
        }

        public StudentAssignment GetStudentAssignmentById(int id)
        {
            StudentAssignment studentAssignment = new StudentAssignment();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = @"SELECT s.student_id, p.name, a.assignment_type, m.module_code, m.module_name, g.grade, g.status
                        FROM student_result r
                            INNER JOIN student s
                            ON r.student_id = s.student_id
                            INNER JOIN person p
                            ON p.person_id = s.person_id
                            INNER JOIN examination e
                            ON r.exam_id = e.exam_id
                            INNER JOIN module m
                            ON e.module_id = m.module_id
                            INNER JOIN assignment a
                            ON e.assignment_id = a.assignment_id
                            INNER JOIN grade g
                            ON r.grade = g.grade
                            WHERE r.student_id = " + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        studentAssignment.StudentID = Convert.ToInt32(rdr["student_id"]);
                        studentAssignment.Name = rdr["name"].ToString();
                        studentAssignment.AssignmentType = rdr["assignment_type"].ToString();
                        studentAssignment.ModuleCode = rdr["module_Code"].ToString();
                        studentAssignment.ModuleName = rdr["module_name"].ToString();
                        studentAssignment.Grade = rdr["grade"].ToString();
                        studentAssignment.Status = rdr["status"].ToString();
                    }
                }
                return studentAssignment;
            }
        }
    }
}