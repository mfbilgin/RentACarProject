using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImageDto>> GetImagesByCarId(int carId);
        IDataResult<List<CarImageDto>> GetImagesByColorId(int colorId);
        IDataResult<List<CarImageDto>> GetImagesByBrandId(int brandId);
        IResult Add(IFormFile file, CarImage carImage, int id);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetAll();
    }
}