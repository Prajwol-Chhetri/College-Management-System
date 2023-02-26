using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollegeManagementSystem.Models;
using Oracle.ManagedDataAccess.Client;


namespace CollegeManagementSystem.Services
{
    public class ModulesService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CMS;PASSWORD=123;";

        // method to Add Modules in database
        public void AddModule(Module module)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("INSERT INTO module (module_code, module_name, credit_hours)" +
                            "VALUES ('{0}','{1}', {2})",
                            module.ModuleCode,
                            module.ModuleName,
                            module.CreditHours);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // method to delete Module from database
        public void DeleteModule(int id)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("DELETE from module WHERE module_id = " + id); ;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to update data in module table
        public void EditModule(Module module)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("UPDATE module SET module_code = '{1}', module_name = '{2}', credit_hours = {3} WHERE module_id = {0}",
                            module.ModuleID,
                            module.ModuleCode,
                            module.ModuleName,
                            module.CreditHours);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to get all data in module table
        public IEnumerable<Module> GetAllModule()
        {
            List<Module> modules = new List<Module>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT module_id, module_code, module_name, credit_hours FROM module";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Module module = new Module
                        {
                            ModuleID = Convert.ToInt32(dataReader["module_id"]),
                            ModuleCode = dataReader["module_code"].ToString(),
                            ModuleName = dataReader["module_name"].ToString(),
                            CreditHours = Convert.ToInt32(dataReader["credit_hours"])
                        };
                        modules.Add(module);
                    }
                }
            }
            return modules;
        }

        public Module GetModuleById(int id)
        {
            Module module = new Module();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "SELECT module_id, module_code, module_name, credit_hours FROM module WHERE module_id =" + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        module.ModuleID = Convert.ToInt32(rdr["module_id"]);
                        module.ModuleCode = rdr["module_code"].ToString();
                        module.ModuleName = rdr["module_name"].ToString();
                        module.CreditHours = Convert.ToInt32(rdr["credit_hours"]);
                    }
                }
            }
            return module;
        }
    }
}