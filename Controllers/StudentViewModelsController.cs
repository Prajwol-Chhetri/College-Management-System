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
    public class StudentViewModelsController : Controller
    {
        private CollegeManagementSystemContext db = new CollegeManagementSystemContext();
        StudentsService studentService = new StudentsService();

        // GET: StudentViewModels
        public ActionResult Index()
        {
            IEnumerable<StudentViewModel> students = studentService.GetAllStudent();
            return View(students);
        }

        // GET: StudentViewModels/Details/5
        public ActionResult Details(int id)
        {
            StudentViewModel student = studentService.GetStudentById(id);
            return View(student);
        }

        // GET: StudentViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                studentService.AddStudents(studentViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: StudentViewModels/Edit/5
        public ActionResult Edit(int id)
        {
            StudentViewModel student = studentService.GetStudentById(id);
            return View(student);
        }

        // POST: StudentViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            try
            {
                studentService.EditStudent(studentViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: StudentViewModels/Delete/5
        public ActionResult Delete(int id)
        {
            StudentViewModel student = studentService.GetStudentById(id);
            return View(student);
        }

        // POST: StudentViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                studentService.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
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
