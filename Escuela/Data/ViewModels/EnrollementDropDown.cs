using Escuela.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Data.ViewModels
{
    public class EnrollementDropDown
    {
        public EnrollementDropDown()
        {
            Courses = new List<Course>();
            Students = new List<Students>();
        }

        public List<Course> Courses { get; set; }
        public List<Students> Students { get; set; }
    }
}
