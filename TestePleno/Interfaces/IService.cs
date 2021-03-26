using System.Collections.Generic;

namespace TestePleno.Interfaces
{
    public interface IService<T, Y>
    {
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        T GetById(Y id);
        List<T> GetAll();
        void DeleteAll();
    }
}