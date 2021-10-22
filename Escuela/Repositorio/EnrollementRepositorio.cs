using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class EnrollementRepositorio : IEnrollements
    {
        private ApplicationDbContext bd;

        public EnrollementRepositorio(ApplicationDbContext bd)
        {
            this.bd = bd;
        }

        public List<Enrollment> UnionDeTablas()
        {
            var union = bd.Enrollments.Include(e => e.Student).Include(c=>c.Course) .ToList();
            return union;
        }


    }
}
