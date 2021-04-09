using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        private readonly  ICarImageService _carImageService;

        public CarManager(ICarDAL carDal, ICarImageService carImageService)
        {
            _carDAL = carDal;
            _carImageService = carImageService;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(7)]
        public IDataResult<Car> Add(Car car)
        {
            _carDAL.Add(car);
            return new SuccessDataResult<Car>(car, Messages.added);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDAL.Delete(car);
            return new SuccessResult(Messages.deleted);
        }

        [CacheAspect]
        //[SecuredOperation("list,admin")]
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


        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(7)]
        public IResult Update(Car car)
        {
            _carDAL.Update(car);
            return new SuccessResult(Messages.updated);
        }
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDAL.Get(car=> car.CarId == id), Messages.listed);
        }

        [CacheAspect]
        public IDataResult<CarAndImagesDto> GetCarAndImagesDtoById(int carId)
        {
            var result = _carDAL.GetCarDetail(carId);
            var imageResult = _carImageService.GetAllByCarId(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarAndImagesDto>(Messages.error);
            }

            var carAndImagesDto = new CarAndImagesDto
            {
                Car = result,
                CarImages = imageResult.Data
            };

            return new SuccessDataResult<CarAndImagesDto>(carAndImagesDto, Messages.succeed);
        }
    }
}
