using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Service;

namespace TestePleno.Services
{
    public class FareService : AbstractGenericService<Fare, Guid>
    {

        /*
        private Repository _repository = new Repository();

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }
        */

        public override Fare Insert(Fare entity)
        {
            if (entity.Id == Guid.Empty)
                throw new Exception("Não é possível salvar um registro com Id não preenchido");

            var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == entity.Id);
            if (modelAlreadyExists)
                throw new Exception($"Já existe um registro para a entidade '{entity.GetType().Name}' com o Id '{entity.Id}'");

            _fakeDatabase.Add(entity);

            return entity;
        }

        public override Fare Update(Fare entity)
        {
            throw new NotImplementedException();
        }

        /*
        public Fare GetById<Fare>(Guid id)
        {
           // Fare model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
           // return model;
        }

        public List<Fare> GetAll<Fare>()
        {
            // var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(Fare)));
           // var convertedModels = allModels.Select(genericModel => (Fare)genericModel).ToList();
           // return convertedModels;
        }
        */
    }
}
