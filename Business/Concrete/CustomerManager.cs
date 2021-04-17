using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDAL _customerDal;

        public CustomerManager(ICustomerDAL customerDal)
        {
            _customerDal = customerDal;
        }
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(customer => customer.CustomerId == CustomerId));
        }

        public IDataResult<Customer> GetByUserId(int UserId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(customer => customer.UserId == UserId));
        }


        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCarDetails());
        }
    }
}
