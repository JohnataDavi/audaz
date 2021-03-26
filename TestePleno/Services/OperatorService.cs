using System;
using System.Linq;
using TestePleno.Models;
using TestePleno.Service;

namespace TestePleno.Services
{
    public class OperatorService : AbstractGenericService<Operator, Guid>
    {

        public OperatorService()
        {
            _fakeDatabase.Add(new Operator("OP01"));
            _fakeDatabase.Add(new Operator("OP02"));
            _fakeDatabase.Add(new Operator("OP03"));
            _fakeDatabase.Add(new Operator("OP04"));
        }

        public override Operator Insert(Operator entity)
        {
            if (entity.Id == Guid.Empty)
                throw new Exception("Não é possível salvar um registro com Id não preenchido");

            var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == entity.Id);
            if (modelAlreadyExists)
                throw new Exception($"Já existe um registro para a entidade '{entity.GetType().Name}' com o Id '{entity.Id}'");

            _fakeDatabase.Add(entity);

            return entity;
        }

        public Operator GetOperatorByCode(string code)
        {
            var operators = GetAll();
            var selectedOperator = operators.FirstOrDefault(o => o.Code == code);
            return selectedOperator;
        }

        public void AddFare(Operator op, Fare fare)
        {
            var operators = GetAll();
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i].Id == op.Id)
                {
                    bool equalFare = false;
                    for (int j = 0; j < operators[i].Fares.Count; j++)
                    {
                        // Tarifas com valores iguais
                        Fare aux = operators[i].Fares[j];
                        if (aux.Value == fare.Value)
                        {
                            DateTime date = fare.UpdatedAt.AddMonths(-6);
                            // A tarifa de mesmo valor encontrada está registrada a mais de 6 meses
                            if (DateTime.Compare(aux.UpdatedAt, date) < 0)
                            {
                                if (aux.Status == 0)
                                {
                                    operators[i].Fares[j].Status = 1;
                                    operators[i].Fares[j].UpdatedAt = DateTime.Now;
                                }
                            }
                            equalFare = true;
                            break;
                        }
                    }
                    if (!equalFare)
                    {
                        operators[i].Fares.Add(fare);
                    }
                    break;
                }
            }
        }

        public override Operator GetById(Guid id)
        {
            Operator model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
            return model;
        }
    }
}
