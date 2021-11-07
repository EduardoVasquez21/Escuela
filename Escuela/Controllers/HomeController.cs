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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourese icourse;
        private IEnrollements ienrollements;
        private IStudent istudent;
        public HomeController(ILogger<HomeController> logger, ICourese icourse, IEnrollements ienrollements, IStudent istudent)
        {
            this.icourse = icourse;
            this.ienrollements = ienrollements;
            this.istudent = istudent;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //for (int i = 0; i <= 100; i++)
            //{
            //    Course course = new Course();
            //    course.Title = "Poooh";
            //    course.Credits = 100;
            //    icourse.Insertar(course);

            //}

            //var listado = ienrollements.UnionDeTablas();
            //_ = listado;


            return View();
        }

        //public IActionResult combobox()
        //{
        //    var informationofthecombo = icourse.ListarCursos();
        //    var informationofthecomboforStudents = istudent.ListOfStudents();


        //    List<SelectListItem> listOfCourse = new List<SelectListItem>();
        //    List<SelectListItem> listStudent = new List<SelectListItem>();


        //    foreach (var iterarinformation in informationofthecombo)
        //    {
        //        listOfCourse.Add(
        //            new SelectListItem
        //            {
        //                Text = iterarinformation.Title,
        //                Value = Convert.ToString(iterarinformation.CourseId)
        //            }

        //            );
        //        ViewBag.estadolistcourse = listOfCourse;
        //    }

        //    foreach (var iterarinformation in informationofthecomboforStudents)
        //    {
        //        listStudent.Add(
        //            new SelectListItem
        //            {
        //                Text = iterarinformation.FirstMidName,
        //                Value = Convert.ToString(iterarinformation.StudentId)
        //            }

        //            );
        //        ViewBag.estadoliststudent = listStudent;
        //    }


        //    return View();
        //}

        //public IActionResult GetinformationCombobox(Enrollment e)
        //{
        //    _ = e;
        //    Console.WriteLine(e.CourseID);
        //    return View("combobox");
        //}

        //public IActionResult Indextres()
        //{

        //    var listado = ienrollements.UnionDeTablas();
        //    _ = listado;


        //    return View(listado);
        //}

        public IActionResult GetAllForJoinJsonLinq()
        {
            var listado = ienrollements.UnionDeTablas();
            var CombinacionDeArreglos = (from union in listado
                                         select new
                                         {
                                             union.Course.Title,
                                             union.Student.LastName,
                                             union.Student.FirstMidName,
                                             union.Grade
                                         }).ToList();

            return Json(new { CombinacionDeArreglos});
        }

        //{"combinacionDeArreglos":[{"title":"Bd","lastName":"Vasquez","firstMidName":"Eduardo","grade":10},{"title":"Bd","lastName":"Vasquez","firstMidName":"Eduardo","grade":9}]}

        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
