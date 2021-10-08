using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
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
        public HomeController(ILogger<HomeController> logger, ICourese icourse)
        {
            this.icourse = icourse;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Course course = new Course();
            //course.Title = "Poooh";
            //course.Credits = 100;
            //icourse.Insertar(course);
            return View();
        }
        
        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }

        public IActionResult Indexdos(String Title, int Credits)
        {
            Course course = new Course();
            course.Title = Title;
            course.Credits = Credits;
            icourse.Insertar(course);
            return View();
        }

        //public IActionResult Indexdos()
        //{
        //    return View();
        //}
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
