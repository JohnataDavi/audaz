using System;
using TestePleno.Utils;

namespace TestePleno.Views
{
    class MainView : View
    {
        public OptionMain getOptionMainView()
        {
            OptionMain option = OptionMain.EXIT;

            bool invalidInput = false;
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("     MENU PRINCIPAL           ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Opções:");
                Console.WriteLine("1 - Tarifa");
                Console.WriteLine("2 - Operadora");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("------------------------------");
                if (invalidInput)
                {
                    Console.WriteLine("-> A opção escolhida foi inválida!");
                }
                Console.WriteLine("Opção: ");
                string x = Console.ReadLine();

                try
                {
                    int op = int.Parse(x);
                    invalidInput = false;
                    switch (op)
                    {
                        case 0:
                            option = OptionMain.EXIT;
                            break;
                        case 1:
                            option = OptionMain.FARE;
                            break;
                        case 2:
                            option = OptionMain.OPERATOR;
                            break;
                        default:
                            invalidInput = true;
                            break;
                    }
                }
                catch (Exception)
                {
                    invalidInput = true;
                }
            } while (invalidInput);

            return option;
        }
    }
}
