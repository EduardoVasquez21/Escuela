using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Data.Base
{
    public interface IEntBase<T> where T: class, Ibase, new()
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
        void Save(T ent);

        void Update(int id, T ent);
        void Delete(int id);

        //void Buscar(T ent);
    }
}
