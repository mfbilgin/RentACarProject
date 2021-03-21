using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        private ICarImageService _carImageService;

        public CarManager(ICarDAL carDAL, ICarImageService carImageService)
        {
            _carDAL = carDAL;
            _carImageService = carImageService;
        }
        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        [PerformanceAspect(7)]
        public IResult Add(Car car)
        {
            _carDAL.Add(car);
            
            return new SuccessResult(Messages.ProductAdded);
        }
        [CacheAspect]
        //[SecuredOperation("car.add,admin")]
        [PerformanceAspect(7)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(), Messages.ProductsListed);
        }

        [CacheAspect]
        [PerformanceAspect(7)]
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
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(), Messages.succeed);
        }

        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(c => c.CarId == id), Messages.succeed);
        }
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetAllCarDetails(c => c.BrandId == id), Messages.succeed);
        }
        [CacheAspect]
        [PerformanceAspect(7)]
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
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(), Messages.listed);
        }

        public IDataResult<CarAndImagesDto> GetCarAndImagesDto(int carId)
        {
            var result = _carDAL.GetCarDetail(carId);
            var imageResult = _carImageService.GetAllByCarId(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarAndImagesDto>(Messages.error);
            }

            var carDetailAndImagesDto = new CarAndImagesDto
            {
                Car = result,
                CarImages = imageResult.Data
            };

            return new SuccessDataResult<CarAndImagesDto>(carDetailAndImagesDto, Messages.succeed);
        }
    }
}
