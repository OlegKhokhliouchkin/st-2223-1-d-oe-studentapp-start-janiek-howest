using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Students.Web.Models;
using Wba.Oefening.Students.Core;

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
           
            return View();
        }

      
    }
}
