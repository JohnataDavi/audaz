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

        public override Fare GetById(Guid id)
        {
            Fare model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
            return model;
        }
    }
}
