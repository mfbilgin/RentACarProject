using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDAL : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDAL
    {
        public List<CustomerDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email
                             };
                return result.ToList();
            }
        }
    }
}
