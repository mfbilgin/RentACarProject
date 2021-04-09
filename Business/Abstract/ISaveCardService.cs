using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISaveCardService
    {
        IResult Add(SavedDebitCard debitCard);
        IDataResult<List<SavedDebitCard>> GetAll();
        IDataResult<List<SavedDebitCard>> GetByUserId(int userId);
        IDataResult<SavedDebitCard> GetByCardNumber(string cardNumber);

    }
}
