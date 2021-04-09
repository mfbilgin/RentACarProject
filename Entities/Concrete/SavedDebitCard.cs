using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SavedDebitCard:IEntity
    {
        public int SavedDebitCardId { get; set; }
        public int UserId { get; set; }
        public string CardholderName { get; set; }
        public string CardholderLastName { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpirationDate { get; set; }
    }
}
