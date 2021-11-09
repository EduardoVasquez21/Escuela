using Escuela.Data.Base;
using Escuela.Data.ViewModels;
using Escuela.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Servicio
{
    public interface IEnrollements:IEntBase<Enrollment>
    {
        Enrollment GetEnrollmentById(int id);
        EnrollementDropDown GetNewEnrollmentValues();

        void AddEnrollement(EnrollementViewModel data);
        void UpdateEnrollement(EnrollementViewModel data);
        void DeleteEnrollement(EnrollementViewModel data);
        
    }
}
