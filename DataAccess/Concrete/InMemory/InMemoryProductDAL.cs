using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDAL : ICarDAL
    {
        public InMemoryProductDAL()
        {
            _products = new List<Car>
            {
                new Car{CarId = 1, BrandId =1, ColorId=1, DailyPrice=400, ModelYear = 2013, Descript = "Siyah Volkswagen Passat"},
                new Car{CarId = 2, BrandId =2, ColorId=3, DailyPrice=800, ModelYear = 2020, Descript = "Kırmızı Tesla Model S"},
                new Car{CarId = 3, BrandId =2, ColorId=1, DailyPrice=750, ModelYear = 2019, Descript = "Siyah Tesla Model 3"},
                new Car{CarId = 4, BrandId =3, ColorId=2, DailyPrice=450, ModelYear = 2015, Descript = "Beyaz Audi A4"},
                new Car{CarId = 5, BrandId =4, ColorId=2, DailyPrice=250, ModelYear = 2009, Descript = "Beyaz Fiat Doblo"}
            };
        }
        List<Car> _products;
        public void Add(Car product)
        {
            _products.Add(product);
        }

        public void Delete(Car product)
        {
            Car productToDelete = _products.SingleOrDefault(car => car.CarId == product.CarId);
            _products.Remove(productToDelete);
        }
        public void Update(Car product)
        {
            Car productToUpdate = _products.SingleOrDefault(car => car.CarId == product.CarId);
            product.DailyPrice = productToUpdate.DailyPrice;
            product.ColorId = productToUpdate.ColorId;
            product.Descript = productToUpdate.Descript;
        }
        public List<Car> GetAll()
        {
            return _products;
        }

        public List<Car> GetAllById(int Id)
        {
            return _products.Where(car => car.CarId == Id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
