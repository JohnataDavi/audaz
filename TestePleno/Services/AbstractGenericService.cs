using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Interfaces;

namespace TestePleno.Service
{
    public abstract class AbstractGenericService<T, Y> : IService<T, Y>
    {
        protected List<T> _fakeDatabase;

        public AbstractGenericService()
        { 
            _fakeDatabase = new List<T>();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(T)));
            var convertedModels = allModels.Select(genericModel => (T)genericModel).ToList();
            return convertedModels;
        }

        public T GetById(Y id)
        {
            throw new NotImplementedException();
        }

        public abstract T Insert(T entity);

        public abstract T Update(T entity);
    }
}
