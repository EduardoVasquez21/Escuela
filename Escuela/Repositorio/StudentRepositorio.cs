using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class StudentRepositorio : IStudent
    {
        private ApplicationDbContext bd;

        public StudentRepositorio(ApplicationDbContext bd)
        {
            this.bd = bd;
        }
        public void Buscar(Students s)
        {
            bd.Students.Find(s);
        }

        public void Delete(Students s)
        {
            bd.Students.Remove(s);
        }

        public void Save(Students s)
        {
            bd.Add(s);
            bd.SaveChanges();
        }

        public List<Students> ListOfStudents()
        {
            return bd.Students.ToList();
        }


    }
}
