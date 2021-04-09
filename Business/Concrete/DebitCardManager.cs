using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class DebitCardManager:IDebitCardService
   {
        IDebitCardDal _debitCardDal;
        IRentalService _rentalService;

        public DebitCardManager(IDebitCardDal debitCardDal, IRentalService rentalService)
        {
            _debitCardDal = debitCardDal;
            _rentalService = rentalService;
        }

        [PerformanceAspect(7)]
        public IDataResult<DebitCard> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<DebitCard>(_debitCardDal.Get(dc=> dc.CardNumber == cardNumber));
        }
        [PerformanceAspect(7)]
        public IDataResult<List<DebitCard>> GetAll()
        {
            return new SuccessDataResult<List<DebitCard>>(_debitCardDal.GetAll());
        }

        public IResult CheckCard(string cardNumber) 
        {
            var result = GetByCardNumber(cardNumber);
            if (result != null)
            {
                return new SuccessResult(Messages.CardInfoSuccess);
            }
            return new ErrorResult(Messages.cardInfoError);
        }

        [PerformanceAspect(7)]
        public IResult Add(DebitCard debitCard)
        {
            _debitCardDal.Add(debitCard);
            return new SuccessResult(Messages.added);
        }
        [PerformanceAspect(7)]
        public IResult Delete(DebitCard debitCard)
        {
            _debitCardDal.Delete(debitCard);
            return new SuccessResult(Messages.deleted);
        }
        [PerformanceAspect(7)]
        public IResult Update(DebitCard debitCard)
        {
            _debitCardDal.Update(debitCard);
            return new SuccessResult(Messages.updated);
        }
        [PerformanceAspect(7)]
        public IResult AddBalance(decimal amount, int cardId)
        {
            var result = GetByCardId(cardId);
            foreach (var card in result.Data)
            {
                card.Balance += amount;
                Update(card);
            }

            return new SuccessResult(Messages.succeed);
        }
        [PerformanceAspect(7)]
        public IResult DecreaseBalance(decimal amount, int cardId)
        {
            var result = GetByCardId(cardId);
            foreach (var card in result.Data)
            {
                if (card.Balance >= amount)
                {
                    card.Balance -= amount;
                    Update(card);
                }
                else
                {
                    return new ErrorResult(Messages.InsufficientBalance);
                }

            }

            return new SuccessResult(Messages.succeed);
        }
        [PerformanceAspect(7)]
        public IDataResult<List<DebitCard>> GetByCardId(int cardId)
        {
            return new SuccessDataResult<List<DebitCard>>(_debitCardDal.GetAll(dc => dc.DebitCardId == cardId));
        }

        public IResult AddRental(string cardNumber, Rental rental,decimal amount)
        {
            IResult decraseBalance = new ErrorResult();
                var result = CheckCard(cardNumber);

            if (result.Success)
            {
                var card = GetByCardNumber(cardNumber).Data;

                decraseBalance = DecreaseBalance(amount, card.DebitCardId);
                  if (decraseBalance.Success)
                {
                    _rentalService.Add(rental);
                    return new SuccessResult(decraseBalance.Message);
                }
                return new ErrorResult(decraseBalance.Message);
                
            }
            return new ErrorResult(result.Message);
            
        }
    }
}
