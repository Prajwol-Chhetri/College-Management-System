using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollegeManagementSystem.Models;
using Oracle.ManagedDataAccess.Client;


namespace CollegeManagementSystem.Services
{
    public class PersonsService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CMS;PASSWORD=123;";

        // method to Add Persons in database
        public void AddPerson(Person person)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("INSERT INTO person (name, email, gender, phone) " +
                            "VALUES ('{0}','{1}','{2}',{3})",
                            person.Name,
                            person.Email,
                            person.Gender,
                            person.Phone);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // method to delete Person from database
        public void DeletePerson(int id)
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


        // function to update data in person table
        public void EditPerson(Person person)
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
                            person.PersonID,
                            person.Name,
                            person.Email,
                            person.Gender,
                            person.Phone);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to get all data in person table
        public IEnumerable<Person> GetAllPerson()
        {
            List<Person> persons = new List<Person>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT person_id, name, email, gender, phone FROM PERSON";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Person person = new Person
                        {
                            PersonID = Convert.ToInt32(dataReader["person_id"]),
                            Name = dataReader["name"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Gender = dataReader["gender"].ToString(),
                            Phone = Int64.Parse(dataReader["phone"].ToString())
                        };
                        persons.Add(person);
                    }
                }
            }
            return persons;
        }

        public Person GetPersonById(int id)
        {
            Person person = new Person();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "SELECT person_id, name, email, gender, phone FROM PERSON WHERE person_id = " + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        person.PersonID = Convert.ToInt32(rdr["person_id"]);
                        person.Name = rdr["name"].ToString();
                        person.Email = rdr["email"].ToString();
                        person.Gender = rdr["gender"].ToString();
                        person.Phone = Int64.Parse(rdr["phone"].ToString());
                    }
                }
            }
            return person;
        }
    }
}