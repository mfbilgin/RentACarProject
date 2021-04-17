using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();
        IDataResult<Customer> GetByCustomerId(int customerId);
        IDataResult<Customer> GetByUserId(int userId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        
    }
}
