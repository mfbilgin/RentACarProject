using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDAL
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join u in context.Users
                             on r.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 BrandName = c.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 UserName = u.FirstName + " " + u.LastName,
                                 Descript = c.Descript
                             };
                return result.ToList();
            }
        }
    }
}