using Escuela.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Dominio
{
    public class Students:Ibase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "REQUIRED DATA")]
        public string LastName { get; set; }

        [Display(Name = "FirstMidName")]
        [Required(ErrorMessage = "REQUIRED DATA")]
        public string FirstMidName { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "REQUIRED DATA")]
        public DateTime EnrollmentsDate { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }



    }
}
