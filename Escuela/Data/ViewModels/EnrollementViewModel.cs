using Escuela.Data.Enum;
using Escuela.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Data.ViewModels
{
    public class EnrollementViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Selecciona un curso")]
        [Required(ErrorMessage = "El curso es requerido")]
        public int CourseID { get; set; }


        [Display(Name = "Selecciona un estudiante")]
        [Required(ErrorMessage = "El curso es requerido")]
        public int StudentID { get; set; }


        [Display(Name = "Selecciona un curso")]
        [Required(ErrorMessage = "El curso es requerido")]
        public Grade? Grade { get; set; }
    
        public bool State { get; set; }
    }
}
