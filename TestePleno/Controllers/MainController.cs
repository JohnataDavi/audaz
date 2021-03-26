using System;
using TestePleno.Utils;
using TestePleno.Views;

namespace TestePleno.Controllers
{
    public class MainController
    {
        private MainView screen = new MainView();
        private OptionMain option;
        private FareController fareController;
        private OperatorController operatorController;

         public MainController()
        {
            operatorController = new OperatorController();
            fareController = new FareController(operatorController.GetService());
        }

        public void Run()
        {
            do
            {
                option = screen.getOptionMainView();
                switch (option)
                {
                    case OptionMain.FARE:
                        fareController.Run();
                        break;
                    case OptionMain.OPERATOR:
                        operatorController.Run();
                        break;
                    case OptionMain.EXIT:
                        screen.ShowMessage("Fim do Programa...");
                        break;
                }
            } while (option != OptionMain.EXIT);
        }
    }
}
