using Escuela.Data;
using Escuela.Data.Base;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class CourseRepositorio : EBaseRep<Course>, ICourese
    {
        public CourseRepositorio(ApplicationDbContext bd) : base(bd)
        {

        }
    }
}
