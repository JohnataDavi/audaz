using System;
using TestePleno.Models;
using TestePleno.Utils;

namespace TestePleno.Views
{
    class FareView : AbstractEntityView<Fare>
    {
        public OptionMain getOptionView()
        {
            OptionMain option = OptionMain.RETURN;

            bool invalidInput = false;
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("         MENU TARIFA           ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Opções:");
                Console.WriteLine("1 - Cadastrar:");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("0 - Voltar");
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
                            option = OptionMain.RETURN;
                            invalidInput = false;
                            break;
                        case 1:
                            option = OptionMain.CREATE;
                            break;
                        case 2:
                            option = OptionMain.READ;
                            break;
                        case 3:
                            option = OptionMain.DELETE;
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

        public (Fare, string) Create()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("       CADASTRAR TARIFA        ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Forneça os dados:");
            Console.WriteLine("Valor da tarifa a ser cadastrada:");
            var fareValueInput = Console.ReadLine();
            Fare fare = new Fare(decimal.Parse(fareValueInput));

            Console.WriteLine("Informe o código da operadora para a tarifa:");
            Console.WriteLine("Exemplos: OP01, OP02, OP03...");
            var operatorCodeInput = Console.ReadLine();

            return (fare, operatorCodeInput);
        }
    }
}
