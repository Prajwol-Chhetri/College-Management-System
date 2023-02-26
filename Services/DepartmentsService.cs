using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollegeManagementSystem.Models;
using Oracle.ManagedDataAccess.Client;


namespace CollegeManagementSystem.Services
{
    public class DepartmentsService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CMS;PASSWORD=123;";

        // method to Add department in database
        public void AddDepartment(Department department)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("INSERT INTO department (department_name, department_description)" +
                            "VALUES ('{0}','{1}')",
                            department.DepartmentName,
                            department.DepartmentDescription);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // method to delete department from database
        public void DeleteDepartment(int id)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("DELETE from department WHERE department_id = " + id); ;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to update data in department table
        public void EditDepartment(Department department)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("UPDATE department SET department_name = '{1}', department_description = '{2}' WHERE department_id = {0}",
                            department.DepartmentID,
                            department.DepartmentName,
                            department.DepartmentDescription);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to get all data in department table
        public IEnumerable<Department> GetAllDepartment()
        {
            List<Department> departments = new List<Department>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT department_id, department_name, department_description FROM department";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Department department = new Department
                        {
                            DepartmentID = Convert.ToInt32(dataReader["department_id"]),
                            DepartmentName = dataReader["department_name"].ToString(),
                            DepartmentDescription = dataReader["department_description"].ToString()
                        };
                        departments.Add(department);
                    }
                }
            }
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            Department department = new Department();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "SELECT department_id, department_name, department_description FROM department WHERE department_id =" + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        department.DepartmentID = Convert.ToInt32(rdr["department_id"]);
                        department.DepartmentName = rdr["department_name"].ToString();
                        department.DepartmentDescription = rdr["department_description"].ToString();
                    }
                }
            }
            return department;
        }
    }
}