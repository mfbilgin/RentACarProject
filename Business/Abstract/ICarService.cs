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
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId);
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IResult Add(Car car);
        IResult AddTransactionalTest(Car car);
    }
}
