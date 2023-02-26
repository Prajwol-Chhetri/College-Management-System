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
    public class TeacherViewModelsController : Controller
    {
        private CollegeManagementSystemContext db = new CollegeManagementSystemContext();
        TeachersService teacherService = new TeachersService();

        // GET: TeacherViewModels
        public ActionResult Index()
        {
            IEnumerable<TeacherViewModel> teachers = teacherService.GetAllTeacher();
            return View(teachers);
        }

        // GET: TeacherViewModels/Details/5
        public ActionResult Details(int id)
        {
            TeacherViewModel teacher = teacherService.GetTeacherById(id);
            return View(teacher);
        }

        // GET: TeacherViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherViewModel teacherViewModel)
        {
            try
            {
                teacherService.AddTeachers(teacherViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: TeacherViewModels/Edit/5
        public ActionResult Edit(int id)
        {
            TeacherViewModel teacher = teacherService.GetTeacherById(id);
            return View(teacher);
        }

        // POST: TeacherViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherViewModel teacherViewModel)
        {
            try
            {
                teacherService.EditTeacher(teacherViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: TeacherViewModels/Delete/5
        public ActionResult Delete(int id)
        {
            TeacherViewModel teacher = teacherService.GetTeacherById(id);
            return View(teacher);
        }

        // POST: TeacherViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                teacherService.DeleteTeacher(id);
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
