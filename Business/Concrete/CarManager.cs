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
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(c => c.BrandId == brandId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(c => c.ColorId == colorId));
        }
    }
}
