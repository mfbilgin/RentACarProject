using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentDto
    {
        public Rental Rental { get; set; }
        public decimal Amount { get; set; }
        public DebitCard DebitCard { get; set; }
    }
}
