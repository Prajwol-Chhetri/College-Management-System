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
    public class TeacherModuleViewModelsController : Controller
    {
        private CollegeManagementSystemContext db = new CollegeManagementSystemContext();
        TeacherModuleService teacheerModuleService = new TeacherModuleService();

        // GET: TeacherModuleViewModels
        public ActionResult Index()
        {
            IEnumerable<TeacherModuleViewModel> teacherModules = teacheerModuleService.GetAllTeacherModule();
            return View(teacherModules);
        }

        // GET: TeacherModuleViewModels/Details/5
        public ActionResult Details(int id)
        {
            TeacherModuleViewModel teacherModule = teacheerModuleService.GetTeacherModuleById(id);
            return View(teacherModule);
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
