using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        public List<Car> GetAll()
        {
            return _carDAL.GetAll();
        }
        public List<Car> GetAllByBrandId(int id)
        {
            return _carDAL.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDAL.GetAll(p => p.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDAL.GetCarDetails();
        }
    }
}
