using Escuela.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Dominio
{
    public class Course:Ibase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "REQUIRED DATA")]
        public string Title { get; set; }

        [Display(Name = "Credits")]
        [Required(ErrorMessage = "REQUIRED DATA")]
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
