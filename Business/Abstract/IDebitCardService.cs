using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDebitCardService
    {
        IResult AddRental(DebitCard debitCard, Rental rental, decimal amount);
        IResult Add(DebitCard debitCard);
        IResult Delete(DebitCard debitCard);
        IResult Update(DebitCard debitCard);
        IDataResult<DebitCard> CheckCard(DebitCard card);
        IResult AddBalance(decimal amount, int cardId);
        IResult DecreaseBalance(decimal amount, int cardId);

        IDataResult<DebitCard> GetByCardId(int cardId);
        IDataResult<DebitCard> GetByCardNumber(string cardNumber);

        IDataResult<List<DebitCard>> GetAll();

 
    }
}
