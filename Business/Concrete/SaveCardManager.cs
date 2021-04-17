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
            IResult result = BusinessRules.Run(CheckIfCardExist(debitCard.CardNumber,debitCard.UserId));
            if (result != null)
            {
                return result;
            }
            _saveCardDal.Add(debitCard);
            return new SuccessResult(Messages.SavedCardAdded);
        }

        public IResult Delete(SavedDebitCard debitCard)
        {
            _saveCardDal.Delete(debitCard);
            return new SuccessResult(Messages.SavedCardDeleted);
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

        private IResult CheckIfCardExist(string cardNumber,int userId)
        {
            var checkByNumber = _saveCardDal.Get(dc => dc.CardNumber == cardNumber);
            var checkByUserId = _saveCardDal.GetAll(dc => dc.UserId == userId);
            foreach (var card in checkByUserId)
            {
                if (cardNumber == checkByNumber.CardNumber && cardNumber == card.CardNumber )
                {
                    return new ErrorResult(Messages.CardExist);
                }
            }

            return new SuccessResult();
        }
    }
}
