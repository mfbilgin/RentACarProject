using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
        public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarContext>, ICarImageDal
        {
            public List<CarImageDto> GetCarImageDetails(Expression<Func<CarImage, bool>> filter = null)
            {
                using (RentACarContext context = new RentACarContext())
                {
                    var result = from image in filter == null ? context.CarImages : context.CarImages.Where(filter)
                        join car in context.Cars
                        on image.CarId equals car.CarId
                        select new CarImageDto
                        {   
                            CarId = car.CarId,
                            ImagePath = image.ImagePath
                        };
                    return result.ToList();
                }
            }
        }
}
