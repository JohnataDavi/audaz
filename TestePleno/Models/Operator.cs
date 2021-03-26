using System;
using System.Collections.Generic;

namespace TestePleno.Models
{
    public class Operator : GenericModel
    {
        public string Code { get; set; }
        public List<Fare> Fares { get; set; }

        public Operator(string code)
        {
            Id = Guid.NewGuid();
            Code = code;
            Fares = new List<Fare>();
        }

        public Operator() { }

        public override string ToString()
        {
            string values = "";
            foreach (Fare f in Fares)
            {
                values += f.ToString();
                values += "\n";
            }
            return "Id: " + Id +
                    "\nCode: " + Code +
                    "\nTarifas\n: " + values;
        }
    }
}
