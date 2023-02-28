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
    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly TeacherRepository _teacherRepository;

        public StudentsController()
        {
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
            _teacherRepository = new TeacherRepository();
        }

        public IActionResult Index()
        {
           StudentsIndexViewModel model = new StudentsIndexViewModel();

            model.Students = _studentRepository.Students
                .Select(x => x.FirstName + " " + x.LastName)
                .ToList();

            return View(model);
        }

        public IActionResult ShowStudent(int studentid)
        {
            StudentsShowStudentViewModel model = new StudentsShowStudentViewModel();
            
            var student = _studentRepository.GetStudentById(studentid);
            
            model.Name = student.FirstName + " " + student.LastName;
            model.Courses = student.Courses.Select(x => x.Name).ToList();

            return View(model);
        }

        
    }
}
