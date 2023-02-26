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
    public class StudentAssignmentsController : Controller
    {
        private CollegeManagementSystemContext db = new CollegeManagementSystemContext();
        StudentAssignmentService studentAssignmentService = new StudentAssignmentService();

        // GET: StudentAssignments
        public ActionResult Index()
        {
            IEnumerable<StudentAssignment> studentAssignments = studentAssignmentService.GetAllStudentAssignment();
            return View(studentAssignments);
        }

        // GET: StudentAssignments/Details/5
        public ActionResult Details(int id)
        {
            StudentAssignment studentAssignment = studentAssignmentService.GetStudentAssignmentById(id);
            return View(studentAssignment);
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
