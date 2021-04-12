using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SaveCardManager:ISaveCardService
    {
        private readonly ISaveCardDal _saveCardDal;

        public SaveCardManager(ISaveCardDal saveCardDal)
        {
            _saveCardDal = saveCardDal;
        }


        public IResult Add(SavedDebitCard debitCard)
        {
            IResult result = BusinessRules.Run(CheckIfCardExist(debitCard.CardNumber));
            if (result != null)
            {
                return result;
            }
            _saveCardDal.Add(debitCard);
            return new SuccessResult(Messages.SavedCardAdded);
        }

        public IDataResult<List<SavedDebitCard>> GetAll()
        {
            return new SuccessDataResult<List<SavedDebitCard>>(_saveCardDal.GetAll());

        }

        public IDataResult<SavedDebitCard> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<SavedDebitCard>(_saveCardDal.Get(dc=> dc.CardNumber == cardNumber));
        }

        public IDataResult<List<SavedDebitCard>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<SavedDebitCard>>(_saveCardDal.GetAll(dc=> dc.UserId == userId));
        }

        private IResult CheckIfCardExist(string cardNumber)
        {
            if (_saveCardDal.GetAll(dc=> dc.CardNumber == cardNumber).Count > 0)
            {
                return new ErrorResult(Messages.CardExist);
            }
            return new SuccessResult();
        }
    }
}
