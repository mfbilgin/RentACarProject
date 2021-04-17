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
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDAL _carDal;

        public CarManager(ICarDAL carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(7)]
        public IDataResult<Car> Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessDataResult<Car>(Messages.CarAdded);
        }



        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(7)]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<CarDetailDto> GetCarByCarId(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail(id));
        }
        
        //[CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorAndBrandId(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(car => car.ColorId == colorId && car.BrandId == brandId));
        }
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<CarDetailDto>> GetCarByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.BrandId == id));
        }
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.ColorId == id));
        }
        
        [CacheAspect]
        [PerformanceAspect(7)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(car=> car.CarId == id));
        }
        [CacheAspect]
        //[SecuredOperation("list,admin")]
        [PerformanceAspect(7)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        
    }
}
