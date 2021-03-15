using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDAL : EfEntityRepositoryBase<Car, RentACarContext>, ICarDAL
    {
        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                Console.WriteLine("Ürün silindi !");
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }
        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 DailyPrice = c.DailyPrice,
                                 ColorName = col.ColorName,
                                 BrandName = b.BrandName,
                                 carId = c.CarId,
                                 descript = c.Descript,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
