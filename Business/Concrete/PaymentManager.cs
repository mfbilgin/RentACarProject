using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult ReceivePayment(Payment payment)
        {
            if (payment.Amount > 5000)
            {
                return new ErrorResult(Messages.InsufficientBalance);
            }
            return new SuccessResult(Messages.PaymentCompleted);
        }
    }
}
