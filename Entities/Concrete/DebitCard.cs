using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class DebitCard:IEntity
    {
        public int DebitCardId { get; set; }
        public string CardholderName { get; set; }
        public string CardholderLastName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
        public decimal Balance { get; set; }

    }
}
