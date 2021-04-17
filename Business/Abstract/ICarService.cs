using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById(int id);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Add(Car car);
        IDataResult<CarDetailDto> GetCarByCarId(int id);
        IDataResult<List<CarDetailDto>> GetCarByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColorAndBrandId(int colorId,int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetails();

    }
}
