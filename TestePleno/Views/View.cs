using System;
using System.IO;
using TestePleno.Interfaces;

namespace TestePleno.Views
{
    public class View : IView
    {
        public decimal AskForDecimal(string question)
        {
            ShowMessage(question);
            var input = Console.ReadLine();
            return decimal.Parse(input);
        }

        public Guid AskForId(string question)
        {
            ShowMessage(question);
            var input = Console.ReadLine();
            return Guid.Parse(input);
        }

        public string AskForString(string question)
        {
            ShowMessage(question);
            var input = Console.ReadLine();
            return input;
        }

        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public void ShowMessageWithConfirmation(string msg)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(msg);
            try
            {
                Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine(
                 "{0}: The write operation could not " +
                 "be performed because the specified " +
                 "part of the file is locked.",
                 e.GetType().Name);
            }
        }
    }
}
