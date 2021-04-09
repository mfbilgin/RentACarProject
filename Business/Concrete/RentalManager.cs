using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess;
using Core.Utilities.Business;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading;
using Entities.DTOs;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDAL _rentalDal;

        public RentalManager(IRentalDAL rentalDAL)
        {
            _rentalDal = rentalDAL;
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());  
        }

        public IDataResult<List<Rental>> GetById(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentalId == rentalId));
        }
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var returnDate = rental.ReturnDate;
            rental.ReturnDate = DateTime.MinValue;
            var result = BusinessRules.Run(CheckIfReturnDateNull(rental.CarId),CheckIfReturnDateGreaterThanNow(rental));
            if (result != null)
            {
                return result;
            }

            rental.ReturnDate = returnDate;
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalSuccess);  
        }

        public IResult Update(Rental rental)
        {
            rental.ReturnDate = DateTime.Now;
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.updated);
        }
        [CacheRemoveAspect("ICarService.Get")]

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ProductDeleted);
        }

        private IResult CheckIfReturnDateNull(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Any();

            if (result)
            {
                return new ErrorResult(Messages.ReturnDateError);
            }

            return new SuccessResult();
        }
        private IResult CheckIfReturnDateGreaterThanNow(Rental rental)
        {
            var result = _rentalDal.GetAll(r => rental.ReturnDate > DateTime.Now).Any();

            if (result)
            {
                return new ErrorResult(Messages.ReturnDateError);
            }

            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
