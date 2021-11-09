using Escuela.Data.Base;
using Escuela.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Dominio
{


    public class Enrollment:Ibase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CourseID { get; set; }


        public int StudentID { get; set; }

        public Grade? Grade { get; set; }

        public Course Course { get; set; }

        public Students Student { get; set; }

        public bool State { get; set; }
    }
}
