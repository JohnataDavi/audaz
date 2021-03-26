using System;
using System.Collections.Generic;
using System.Linq;
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

        public abstract T GetById(Y id);

        public abstract T Insert(T entity);

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        /*
        public abstract T Update(T entity)
        {
            var updatingModel = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == model.Id);
            if (updatingModel == null)
                throw new Exception($"Não há registros para a entidade '{model.GetType().Name}' com Id '{model.Id}'");

            _fakeDatabase.Remove(updatingModel);
            _fakeDatabase.Add(model);
        }
        */

    }
}
