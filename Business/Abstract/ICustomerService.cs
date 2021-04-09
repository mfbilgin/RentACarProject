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
        IDataResult<List<Customer>> GetByCustomerId(int CustomerId);
        IDataResult<List<Customer>> GetByUserId(int UserId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        
    }
}
