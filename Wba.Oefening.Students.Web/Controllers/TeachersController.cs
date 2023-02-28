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
    public class TeachersController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly TeacherRepository _teacherRepository;

        public TeachersController()
        {
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
            _teacherRepository = new TeacherRepository();
        }

        public IActionResult Index()
        {
            TeachersIndexViewModel model = new TeachersIndexViewModel();

            model.Teachers = _teacherRepository.Teachers.Select(x =>
            x.FirstName + " " + x.LastName);

            return View(model);
        }

        public IActionResult Details(int teacherid)
        {
            // initialize view model
            TeachersDetailsViewModel model = new TeachersDetailsViewModel();

            // get domain model
            var teacher = _teacherRepository.GetTeacherById(teacherid);

            // map domain model to viewmodel
            model.Name = teacher.FirstName + "" + teacher.LastName;
            model.Courses = teacher.Courses.Select(x => x.Name);

            // return view with our viewmodel
            return View(model);
        }


    }
}
