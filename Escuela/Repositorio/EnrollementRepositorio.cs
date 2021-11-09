using Escuela.Data;
using Escuela.Data.Base;
using Escuela.Data.ViewModels;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class EnrollementRepositorio : EBaseRep<Enrollment>, IEnrollements
    {
        private ApplicationDbContext bd;

        public EnrollementRepositorio(ApplicationDbContext bd) : base(bd)
        {
            this.bd = bd;
        }
        public new IEnumerable<Enrollment> GetAll()
        {
            var enrolments = bd.Enrollments.Include(n => n.Course).Include(s => s.Student).ToList();
            return enrolments;
        }
        public void AddEnrollement(EnrollementViewModel data)
        {
            var newEnrollment = new Enrollment()
            {
                Grade = data.Grade,
                CourseID = data.CourseID,
                StudentID = data.StudentID,
                State = data.State = true
            };
            bd.Enrollments.Add(newEnrollment);
            bd.SaveChanges();
        }

        public void DeleteEnrollement(EnrollementViewModel data)
        {
            var enrollement = bd.Enrollments.FirstOrDefault(e => e.Id == data.Id);
            if (enrollement != null)
            {
                enrollement.Grade = data.Grade;
                enrollement.CourseID = data.CourseID;
                enrollement.StudentID = data.StudentID;
                enrollement.State = data.State = false;

                bd.SaveChanges();
            }
        }

        public Enrollment GetEnrollmentById(int id)
        {
            var enrollement = bd.Enrollments
                .Include(b => b.Course)
                .Include(s => s.Student)
                .FirstOrDefault(e => e.Id == id);

            return enrollement;
        }

        public EnrollementDropDown GetNewEnrollmentValues()
        {
            var values = new EnrollementDropDown()
            {
                Courses = bd.Courses.OrderBy(c => c.Title).ToList(),
                Students = bd.Students.OrderBy(s => s.LastName).ToList()
            };

            return values;
        }
    
        

        

        public void UpdateEnrollement(EnrollementViewModel data)
        {
            var enrollement = bd.Enrollments.FirstOrDefault(e => e.Id == data.Id);
            if (enrollement != null)
            {
                enrollement.Grade = data.Grade;
                enrollement.CourseID = data.CourseID;
                enrollement.StudentID = data.StudentID;
                enrollement.State = data.State = true;

                bd.SaveChanges();
            }
        }
    }
}
