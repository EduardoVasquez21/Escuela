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
        public HomeController(ILogger<HomeController> logger, ICourese icourse, IEnrollements ienrollements)
        {
            this.icourse = icourse;
            this.ienrollements = ienrollements;
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

        public IActionResult combobox()
        {
            var informationofthecombo = icourse.ListarCursos();


            List<SelectListItem> lista = new List<SelectListItem>();
            foreach (var iterarinformation in informationofthecombo)
            {
                lista.Add(
                    new SelectListItem
                    {
                        Text = iterarinformation.Title,
                        Value = Convert.ToString(iterarinformation.CourseId)
                    }

                    );
                ViewBag.estado = lista;
            }


            return View();
        }

        public IActionResult Indextres()
        {

            var listado = ienrollements.UnionDeTablas();
            _ = listado;


            return View(listado);
        }

        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }

        public IActionResult insert(Course c)
        {

            icourse.Insertar(c);
            return Redirect("Indexdos");
        }

        public IActionResult Indexdos()
        {
            return View();
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
