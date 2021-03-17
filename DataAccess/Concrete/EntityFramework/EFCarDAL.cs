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
        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,

                                 ColorId = color.ColorId,

                                 BrandId = brand.BrandId,

                                 ModelYear = car.ModelYear, 

                                 descript = car.Descript,

                                 DailyPrice = car.DailyPrice,

                                 ColorName = color.ColorName,

                                 BrandName = brand.BrandName
                                 
                             };
                return result.ToList();
            }
        }
    }
}
