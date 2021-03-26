using TestePleno.Interfaces;
using TestePleno.Models;
using TestePleno.Services;
using TestePleno.Utils;
using TestePleno.Views;

namespace TestePleno.Controllers
{
    public class OperatorController : IController<Operator>
    {
        private readonly OperatorView _screen;
        private OperatorService _service;

        public OperatorController()
        {
            _screen = new OperatorView();
            _service = new OperatorService();
        }

        public OperatorService GetService() { return _service;  }

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

        public Operator Find(Operator Object)
        {
            throw new System.NotImplementedException();
        }

        public void List()
        {
            _screen.List(_service.GetAll());
        }

        public void Remove(Operator toRemove)
        {
            List();
            if (toRemove == null)
            {
                toRemove = new Operator
                {
                    Id = _screen.AskForId("Forneça um ID(Guid):")
                };
            }
            _service.Delete(toRemove);
        }

        public Operator Create()
        {
            Operator temp = _screen.Create();
            _service.Insert(temp);
            return temp;
        }
    }
}
