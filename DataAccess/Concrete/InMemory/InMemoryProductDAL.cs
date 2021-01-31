using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDAL : IProductDAL
    {
        public InMemoryProductDAL()
        {
            _products = new List<Product>
            {
                new Product{Id = 1, BrandId =1, ColorId=1, DailyPrice=400, ModelYear = 2013, Description = "Siyah Volkswagen Passat"},
                new Product{Id = 2, BrandId =2, ColorId=3, DailyPrice=800, ModelYear = 2020, Description = "Kırmızı Tesla Model S"},
                new Product{Id = 3, BrandId =2, ColorId=1, DailyPrice=750, ModelYear = 2019, Description = "Siyah Tesla Model 3"},
                new Product{Id = 4, BrandId =3, ColorId=2, DailyPrice=370, ModelYear = 2015, Description = "Beyaz Audi A4"},
                new Product{Id = 5, BrandId =4, ColorId=2, DailyPrice=250, ModelYear = 2009, Description = "Beyaz Fiat Doblo"}
            };
        }
        List<Product> _products;
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(car => car.Id == product.Id);
            _products.Remove(productToDelete);
        }
        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(car => car.Id == product.Id);
            product.DailyPrice = productToUpdate.DailyPrice;
            product.ColorId = productToUpdate.ColorId;
            product.Description = productToUpdate.Description;
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllById(int Id)
        {
            return _products.Where(car => car.Id == Id).ToList();
        }

        
    }
}
