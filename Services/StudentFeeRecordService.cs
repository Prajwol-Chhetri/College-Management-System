using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Services
{
    public class StudentFeeRecordService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CMS;PASSWORD=123;";

        // function to get all data of student fee record mapping table
        public IEnumerable<StudentFeeRecord> GetAllStudentFeeRecord()
        {
            List<StudentFeeRecord> studentFeeRecords = new List<StudentFeeRecord>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = @"SELECT p.person_id, p.name, p.email, p.gender, p.phone, 
                        stu.student_id, 
                        sp.payment_id, sp.amount, sp.date_of_payment, sp.department_id,
                        f.semester_fee_id, f.fee,
                        sem.semester_name
                        FROM PERSON p 
                            INNER JOIN STUDENT stu 
                            ON p.person_id = stu.person_id 
                            INNER JOIN STUDENT_PAYMENT_RECORD sp 
                            ON stu.student_id = sp.student_id
                            INNER JOIN SEMESTER_FEE f
                            ON sp.semester_fee_id = f.semester_fee_id
                            INNER JOIN SEMESTER sem
                            ON f.semester_id = sem.semester_id";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        StudentFeeRecord studentFeeRecord = new StudentFeeRecord
                        {
                            PersonID = Convert.ToInt32(dataReader["person_id"]),
                            Name = dataReader["name"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Gender = dataReader["gender"].ToString(),
                            Phone = Int64.Parse(dataReader["phone"].ToString()),
                            StudentID = Convert.ToInt32(dataReader["student_id"]),
                            PaymentID = Convert.ToInt32(dataReader["payment_id"]),
                            AmountPaid = Convert.ToDecimal(dataReader["amount"]),
                            DateOfPayment = Convert.ToDateTime(dataReader["date_of_payment"]),
                            DepartmentID = Convert.ToInt32(dataReader["department_id"]),
                            SemesterFeeID = Convert.ToInt32(dataReader["semester_fee_id"]),
                            Fee = Convert.ToDecimal(dataReader["fee"]),
                            SemesterName = dataReader["semester_name"].ToString()
                        };
                        studentFeeRecords.Add(studentFeeRecord);
                    }
                }
            }
            return studentFeeRecords;
        }

        public StudentFeeRecord GetStudentFeeRecordById(int id)
        {
            StudentFeeRecord studentFeeRecord = new StudentFeeRecord();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = @"SELECT p.person_id, p.name, p.email, p.gender, p.phone, 
                        stu.student_id, 
                        sp.payment_id, sp.amount, sp.date_of_payment, sp.department_id,
                        f.semester_fee_id, f.fee,
                        sem.semester_name
                        FROM PERSON p 
                            INNER JOIN STUDENT stu 
                            ON p.person_id = stu.person_id 
                            INNER JOIN STUDENT_PAYMENT_RECORD sp 
                            ON stu.student_id = sp.student_id
                            INNER JOIN SEMESTER_FEE f
                            ON sp.semester_fee_id = f.semester_fee_id
                            INNER JOIN SEMESTER sem
                            ON f.semester_id = sem.semester_id
                            WHERE p.person_id = " + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        studentFeeRecord.PersonID = Convert.ToInt32(rdr["person_id"]);
                        studentFeeRecord.Name = rdr["name"].ToString();
                        studentFeeRecord.Email = rdr["email"].ToString();
                        studentFeeRecord.Gender = rdr["gender"].ToString();
                        studentFeeRecord.Phone = Int64.Parse(rdr["phone"].ToString());
                        studentFeeRecord.StudentID = Convert.ToInt32(rdr["student_id"]);
                        studentFeeRecord.PaymentID = Convert.ToInt32(rdr["payment_id"]);
                        studentFeeRecord.AmountPaid = Convert.ToDecimal(rdr["amount"]);
                        studentFeeRecord.DateOfPayment = Convert.ToDateTime(rdr["date_of_payment"]);
                        studentFeeRecord.DepartmentID = Convert.ToInt32(rdr["department_id"]);
                        studentFeeRecord.SemesterFeeID = Convert.ToInt32(rdr["semester_fee_id"]);
                        studentFeeRecord.Fee = Convert.ToDecimal(rdr["fee"]);
                        studentFeeRecord.SemesterName = rdr["semester_name"].ToString();
                    }
                }
                return studentFeeRecord;
            }
        }
    }
}