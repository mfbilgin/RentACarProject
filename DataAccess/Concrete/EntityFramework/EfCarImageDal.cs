using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarContext>, ICarImageDal
    {
        public void Add(CarImage entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(CarImage entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                Console.WriteLine("Ürün silindi !");
            }
        }

        public void Update(CarImage entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public CarImage Get(Expression<Func<CarImage, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<CarImage>().SingleOrDefault(filter);
            }
        }
    }
}
