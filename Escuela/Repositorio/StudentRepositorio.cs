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
    public class StudentRepositorio : EBaseRep<Students>, IStudent
    {
        public StudentRepositorio(ApplicationDbContext bd) : base(bd)
        {

        }

    }
}
