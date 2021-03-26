using TestePleno.Interfaces;
using TestePleno.Models;
using TestePleno.Services;
using TestePleno.Utils;
using TestePleno.Views;

namespace TestePleno.Controllers
{
    public class FareController : IController<Fare>
    {
        private readonly FareView _screen;
        private OperatorService _operatorService;
        private FareService _service;

        public FareController(OperatorService operatorService)
        {
            _screen = new FareView();
            _operatorService = operatorService;
            _service = new FareService();
        }

        public void Run()
        {
            OptionMain option;
            do
            {
                option = _screen.getOptionView();
                switch (option)
                {
                    case OptionMain.CREATE:
                        if (Create() != null)
                        {
                            _screen.ShowMessageWithConfirmation("Cadstrado realizado com sucesso!!!\nDigite qualquer tecla para continuar:");
                        }
                        break;
                    case OptionMain.READ:
                        List();
                        _screen.ShowMessageWithConfirmation("Digite qualquer tecla para continuar...");
                        break;
                    case OptionMain.DELETE:
                        Remove(null);
                        break;
                    default:
                        _screen.ShowMessage("Digite Novamente:");
                        break;
                }
            } while (option != OptionMain.RETURN);
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            _service.Insert(fare);
        }

        public Fare Find(Fare Object)
        {
            throw new System.NotImplementedException();
        }

        public void List()
        {
            _screen.List(_service.GetAll());
        }

        public void Remove(Fare toRemove)
        {
            List();
            if (toRemove == null)
            {
                toRemove = new Fare
                {
                    Id = _screen.AskForId("Forneça um ID(Guid):")
                };
            }
            _service.Delete(toRemove);
        }

        public Fare Create()
        {
            Fare fare;
            string operatorCode;
            (fare, operatorCode) = _screen.Create();

            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            if (selectedOperator == null)
            {
                _screen.ShowMessage("Não existe operadora cadastrada com esse código!");
                _screen.ShowMessageWithConfirmation("Digite qualquer tecla para continuar...");
                return null;
            }

            _operatorService.AddFare(selectedOperator, fare);
            fare = _service.Insert(fare);
            return fare;
        }
    }
}
