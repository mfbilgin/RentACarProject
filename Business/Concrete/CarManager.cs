using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;

        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        [PerformanceAspect(7)]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);

            _carDAL.Add(car);
            
            return new SuccessResult(Messages.ProductAdded);
        }
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(), Messages.ProductsListed);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(c => c.CarId == carId));

        }

        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(p => p.BrandId == id));
        }
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDAL.GetAll(p => p.ColorId == id));
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 1000)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(), Messages.succeed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(c => c.CarId == id), Messages.succeed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(c => c.BrandId == id), Messages.succeed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(c => c.ColorId == id), Messages.succeed);
        }

        public IResult Delete(int carId)
        {

            foreach (var car in _carDAL.GetAll())
            {
                if (car.CarId == carId)
                {
                    _carDAL.Delete(car);
                    return new SuccessResult(Messages.ProductDeleted);

                }
            }
            return new ErrorResult(Messages.error);
        }

        public IResult Update(int carId, Car car)
        {
            foreach (var _car in _carDAL.GetAll())
            {
                if (_car.CarId == carId)
                {
                    _car.ColorId = car.ColorId;
                    _car.BrandId = car.BrandId;
                    _car.ModelYear = car.ModelYear;
                    _car.DailyPrice = car.DailyPrice;
                    _car.Descript = car.Descript;
                    return new SuccessResult(Messages.updated);

                }
            }
            return new SuccessResult(Messages.error);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(), Messages.listed);
        }
    }
}
