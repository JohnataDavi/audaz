using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.Interfaces
{
    public interface IView
    {
        Guid AskForId(string question);
        decimal AskForDecimal(string question);
        string AskForString(string question);
        void ShowMessage(string msg);
    }
}
