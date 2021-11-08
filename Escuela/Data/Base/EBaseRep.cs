using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Data.Base
{
    public class EBaseRep<T> : IEntBase<T> where T : class, Ibase, new()
    {
        private ApplicationDbContext bd;

        public EBaseRep(ApplicationDbContext bd)
        {
            this.bd = bd;
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            var ent = bd.Set<T>().ToList();
            return ent;
        }

        public T GetById(int id)
        {
            var entity = bd.Set<T>().FirstOrDefault(n => n.Id == id);
            return entity;
        }

        public void Save(T ent)
        {
            bd.Set<T>().Add(ent);
            bd.SaveChanges();
        }

        public void Update(int id, T entity)
        {
            EntityEntry entityEntry = bd.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            bd.SaveChanges();
        }
    }
}
