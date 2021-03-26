using System;

namespace TestePleno.Models
{
    public class Fare : GenericModel
    {
        //public Guid OperatorId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Status { get; set; }
        public decimal Value { get; set; }
        public Fare(decimal value)
        {
            UpdatedAt = DateTime.Now;
            Id = Guid.NewGuid();
            Value = value;
            Status = 1;
        }

        public Fare() { }

        public override string ToString()
        {
            return "Id: " + Id +
                    "\nValue: " + Value +
                    "\nStatus: " + Status +
                    "\nUpdateAd: " + UpdatedAt;
        }
    }
}
