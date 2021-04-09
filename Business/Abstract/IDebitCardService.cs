using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDebitCardService
    {
        IResult AddRental(string cardNumber, Rental rental, decimal amount);
        IResult Add(DebitCard debitCard);
        IResult Delete(DebitCard debitCard);
        IResult Update(DebitCard debitCard);
        IResult CheckCard(string cardNumber);
        IResult AddBalance(decimal amount, int cardId);
        IResult DecreaseBalance(decimal amount, int cardId);

        IDataResult<List<DebitCard>> GetByCardId(int cardId);
        IDataResult<DebitCard> GetByCardNumber(string cardNumber);
        IDataResult<List<DebitCard>> GetAll();

 
    }
}
