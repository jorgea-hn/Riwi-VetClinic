
using System.Collections.Generic;

namespace VetClinic.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
