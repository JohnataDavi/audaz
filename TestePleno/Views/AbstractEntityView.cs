using System;
using System.Collections.Generic;

namespace TestePleno.Views
{
    public abstract class AbstractEntityView<T> : View
    {
        public void List(List<T> list)
        {
            if(list.Count < 1)
            {
                Console.WriteLine("Não há dados disponíveis!");
                return;
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("           LISTAGEM           ");
            Console.WriteLine("------------------------------");
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
        }
    }
}
