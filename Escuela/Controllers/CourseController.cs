using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private ICourese icourse;

        public CourseController(ILogger<CourseController> logger, ICourese icourse)
        {
            this.icourse = icourse;
            _logger = logger;
        }
        public IActionResult SaveCourse()
        {
            ViewBag.State = "SaveCourse";
            ViewBag.Titulo = "Add";
            return View("SaveCourse");
        }

        [HttpPost]
        public IActionResult SaveCourse([Bind("Id,Title,Credits")] Course c)
        {
            if (ModelState.IsValid)
            {
                icourse.Save(c);
                return RedirectToAction("MostrarCourses");
            }
            else
            {
                return View(c);
            }

        }

        public IActionResult Update(int id)
        {
            ViewBag.State = "Update";
            ViewBag.Title = "Update Course";
            var CourseEdit = icourse.GetById(id);
            if (CourseEdit == null)
                return View("Error");
            return View(CourseEdit);
        }

        [HttpPost]
        public IActionResult Update(int id,[Bind("Id,Title,Credits")] Course c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }
            icourse.Update(id, c);
            return RedirectToAction("MostrarCourses");

        }
        public IActionResult UpdateEdit()
        {

            return View("Update");
        }

        public IActionResult GetAll()
        {
            var DandoFormatoJsonStudent = icourse.GetAll();

            return Json(new { data = DandoFormatoJsonStudent });
        }

        public IActionResult MostrarCourses()
        {
            var courses = icourse.GetAll();

            return View(courses);
        }

    }
}
