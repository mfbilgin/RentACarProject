using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Utilities.Business;
using Microsoft.EntityFrameworkCore.Internal;
using Entities.DTOs;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDAL _rentalDal;

        public RentalManager(IRentalDAL rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());  
        }

        public IDataResult<Rental>GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(rental => rental.RentalId == rentalId));
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(rental => rental.CarId == carId));
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
            return new SuccessResult(Messages.RentalUpdated);
        }
        [CacheRemoveAspect("ICarService.Get")]

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        private IResult CheckIfReturnDateNull(int carId)
        {
            var result = _rentalDal.GetAll(rental => rental.CarId == carId && rental.ReturnDate == null).Any();

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
