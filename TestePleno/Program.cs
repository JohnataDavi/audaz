using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Controllers;
using TestePleno.Models;

namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            MainController mainController = new MainController();
            mainController.Run();
            /*
            Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
            var fareValueInput = Console.ReadLine();
            Fare fare = new Fare(decimal.Parse(fareValueInput));

            Console.WriteLine("Informe o código da operadora para a tarifa:");
            Console.WriteLine("Exemplos: OP01, OP02, OP03...");
            var operatorCodeInput = Console.ReadLine();

            var fareController = new FareController();
            fareController.CreateFare(fare, operatorCodeInput);

            Console.WriteLine("Tarifa cadastrada com sucesso!");
            Console.Read();
            */
        }
    }
}
