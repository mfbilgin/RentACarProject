using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
   public class DebitCardManager:IDebitCardService
   {
       private readonly IDebitCardDal _debitCardDal;
       private readonly IRentalService _rentalService;

        public DebitCardManager(IDebitCardDal debitCardDal, IRentalService rentalService)
        {
            _debitCardDal = debitCardDal;
            _rentalService = rentalService;
        }

        [PerformanceAspect(7)]
        public IDataResult<DebitCard> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<DebitCard>(_debitCardDal.Get(dc => dc.CardNumber == cardNumber));
        }
        [PerformanceAspect(7)]
        public IDataResult<List<DebitCard>> GetAll()
        {
            return new SuccessDataResult<List<DebitCard>>(_debitCardDal.GetAll());
        }

        public IDataResult<DebitCard> CheckCard(DebitCard card) 
        {
            var checkByNumber = _debitCardDal.Get(dc => dc.CardNumber == card.CardNumber);
            var checkByExprationDate = _debitCardDal.Get(dc => dc.ExpirationDate == card.ExpirationDate);
            var checkByCvv = _debitCardDal.Get(dc => dc.CVV == card.CVV);
            var checkByFirstName = _debitCardDal.Get(dc => dc.CardholderName == card.CardholderName);
            var checkByLastName = _debitCardDal.Get(dc => dc.CardholderLastName == card.CardholderLastName);
            if (checkByNumber == null || checkByExprationDate == null || checkByCvv == null || checkByFirstName == null || checkByLastName == null )
            {
                return new ErrorDataResult<DebitCard>(checkByNumber,Messages.CardInfoError);

            }
            return new SuccessDataResult<DebitCard>(checkByNumber,Messages.CardInfoSuccess);

        }

        [PerformanceAspect(7)]
        public IResult Add(DebitCard debitCard)
        {
            _debitCardDal.Add(debitCard);
            return new SuccessResult(Messages.CardAdded);
        }
        [PerformanceAspect(7)]
        public IResult Delete(DebitCard debitCard)
        {
            _debitCardDal.Delete(debitCard);
            return new SuccessResult(Messages.CardUpdated);
        }
        [PerformanceAspect(7)]
        public IResult Update(DebitCard debitCard)
        {
            _debitCardDal.Update(debitCard);
            return new SuccessResult(Messages.CardUpdated);
        }
        [PerformanceAspect(7)]
        public IResult AddBalance(decimal amount, int cardId)
        {
            var card = GetByCardId(cardId).Data;
            card.Balance += amount;
            Update(card);
            return new SuccessResult(Messages.BalanceAdded);
        }
        [PerformanceAspect(7)]
        public IResult DecreaseBalance(decimal amount, int cardId)
        {
            var card = GetByCardId(cardId).Data;
           
            if (card.Balance >= amount)
            {
                card.Balance -= amount;
                Update(card);
            }
            else
            { 
                return new ErrorResult(Messages.InsufficientBalance);
            }
            
            return new SuccessResult(Messages.BalanceDecrased);
        }
        [PerformanceAspect(7)]
        public IDataResult<DebitCard> GetByCardId(int cardId)
        {
            return new SuccessDataResult<DebitCard>(_debitCardDal.Get(dc => dc.DebitCardId == cardId));
        }

        public IResult AddRental(DebitCard debitCard, Rental rental,decimal amount)
        {
            var result = CheckCard(debitCard);
            if (result.Success)
            {
               var decraseBalance = DecreaseBalance(amount, result.Data.DebitCardId);
               var addBalancetoMe = AddBalance(amount,1);
                  if (decraseBalance.Success || addBalancetoMe.Success)
                  {
                      _rentalService.Add(rental);
                      return new SuccessResult(Messages.RentalSuccess);
                  }
                  return new ErrorResult(decraseBalance.Message);
                
            }
            return new ErrorResult(result.Message);
            
        }
    }
}
