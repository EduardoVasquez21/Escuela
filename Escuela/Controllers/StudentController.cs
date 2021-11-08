using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private IStudent istudent;

        public StudentController(ILogger<StudentController> logger, IStudent istudent)
        {
            this.istudent = istudent;
            _logger = logger;
        }


        public  IActionResult SaveStu()
        {
            //ViewBag.State = "Create";
            return View();
        }

        [HttpPost]
        public IActionResult SaveStu([Bind("Id,LastName,FirstMidName,EnrollmentDate")] Students s)
        {
            if (ModelState.IsValid)
            {
                istudent.Save(s);
                return RedirectToAction("MostrarAlumnos");
            }
            else
            {
                return View(s);
            }

        }

        public IActionResult Update(int id )
        {
            ViewBag.State = "Update";
            var studEdit = istudent.GetById(id);
            if (studEdit == null) 
                return View("Error");
            return View(studEdit);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,LastName,FirstMidName,EnrollmentDate")] Students s)
        {
            if (!ModelState.IsValid)
            {
                return View(s);
            }
            istudent.Update(id, s);
            return RedirectToAction("MostrarAlumnos");

        }
        public IActionResult UpdateEdit()
        {
           
            return View("Update");
        }
        //public IActionResult Edit()
        //{
        //    //Update(null, "SaveStu");
        //    return View("Update");
        //}
        public IActionResult GetAll()
        {
            var DandoFormatoJsonStudent = istudent.GetAll();

            return Json(new { data = DandoFormatoJsonStudent });
        }

        public IActionResult MostrarAlumnos()
        {
            return View();
        }

    }
}
