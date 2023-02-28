using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Students.Web.Models;
using Wba.Oefening.Students.Core;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly TeacherRepository _teacherRepository;

        public CoursesController()
        {
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
            _teacherRepository = new TeacherRepository();
        }

        public IActionResult Index()
        {
            CoursesIndexViewModel model = new CoursesIndexViewModel();
            model.Courses = _courseRepository.Courses.Select(p => p.Name).ToList();
            return View(model);
        }

        public IActionResult Details(int courseid)
        {
            CoursesDetailsViewModel model = new CoursesDetailsViewModel();
            model.CourseName = _courseRepository.GetCourseById(courseid)?.Name;
            model.Students = _studentRepository.GetStudentsInCourseId(courseid).Select(x => x.FirstName + " " + x.LastName).ToList();
            return View(model);
        }

       
    }
}
