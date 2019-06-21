using System;
using System.Linq;

namespace WebAPISample1.Models.Repository
{
    public interface IStudentRepository<TEntity>
    {
        IQueryable GetAll();
        TEntity Get(int id);
        TEntity Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
    }
}
