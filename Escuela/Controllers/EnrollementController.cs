using Escuela.Data.ViewModels;
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
    public class EnrollementController : Controller
    {
        private readonly ILogger<EnrollementController> _logger;
        private ICourese icourse;
        private IEnrollements ienrollements;
        private IStudent istudent;

        public EnrollementController(ILogger<EnrollementController> logger, ICourese icourse, IEnrollements ienrollements, IStudent istudent)
        {
            this.icourse = icourse;
            this.ienrollements = ienrollements;
            this.istudent = istudent;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var enrollements = ienrollements.GetAll().Where(e => e.State == true);
            return View(enrollements);

        }

        public IActionResult Save()
        {
            var EnrollementDropDown = ienrollements.GetNewEnrollmentValues();
            ViewBag.Students = new SelectList(EnrollementDropDown.Students, "Id", "FirstMidName");
            ViewBag.Courses = new SelectList(EnrollementDropDown.Courses, "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Save(EnrollementViewModel enrollement)
        {
            if (!ModelState.IsValid)
            {
                var enrollementData = ienrollements.GetNewEnrollmentValues();
                ViewBag.Students = new SelectList(enrollementData.Students, "Id", "FirstMidName");
                ViewBag.Courses = new SelectList(enrollementData.Courses, "Id", "Title");
                return View(enrollement);
            }
            ienrollements.AddEnrollement(enrollement);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id)
        {
            var enrollment = ienrollements.GetEnrollmentById(id);
            if (enrollment == null)
                return View("Error");

            var response = new EnrollementViewModel()
            {
                Id = enrollment.Id,
                StudentID = enrollment.StudentID,
                CourseID = enrollment.CourseID,
                Grade = enrollment.Grade,
            };

            var enrollmentData = ienrollements.GetNewEnrollmentValues();
            ViewBag.Students = new SelectList(enrollmentData.Students, "Id", "FirstMidName");
            ViewBag.Courses = new SelectList(enrollmentData.Courses, "Id", "Title");

            return View(response);
        }

        [HttpPost]
        public IActionResult Update(int id, EnrollementViewModel enrollment)
        {
            if (id != enrollment.Id)
                return View("Error");

            if (!ModelState.IsValid)
            {
                var enrollmentData = ienrollements.GetNewEnrollmentValues();
                ViewBag.Students = new SelectList(enrollmentData.Students, "Id", "FirstMidName");
                ViewBag.Courses = new SelectList(enrollmentData.Courses, "Id", "Title");
                return View(enrollment);
            }

            ienrollements.UpdateEnrollement(enrollment);
            return RedirectToAction(nameof(Update));

        }

        public IActionResult Delete(int id)
        {
            var enrollement = ienrollements.GetEnrollmentById(id);
            if (enrollement == null)
                return View("Error");

            var response = new EnrollementViewModel()
            {
                Id = enrollement.Id,
                StudentID = enrollement.StudentID,
                CourseID = enrollement.CourseID,
                Grade = enrollement.Grade,
                State = enrollement.State = false
            };

            ienrollements.DeleteEnrollement(response);
            return RedirectToAction(nameof(Index));
        }



    }
}