using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Services;


namespace CollegeManagementSystem.Controllers
{
    public class StudentFeeRecordsController : Controller
    {
        private CollegeManagementSystemContext db = new CollegeManagementSystemContext();
        StudentFeeRecordService studentFeeRecordService = new StudentFeeRecordService();

        // GET: StudentFeeRecords
        public ActionResult Index()
        {
            IEnumerable<StudentFeeRecord> studentFeeRecords = studentFeeRecordService.GetAllStudentFeeRecord();
            return View(studentFeeRecords);
        }

        // GET: StudentFeeRecords/Details/5
        public ActionResult Details(int id)
        {
            StudentFeeRecord studentFeeRecord = studentFeeRecordService.GetStudentFeeRecordById(id);
            return View(studentFeeRecord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
