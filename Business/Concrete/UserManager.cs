using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDAL _userDal;
        public UserManager(IUserDAL userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<User>> GetByUserId(int UserId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.UserId == UserId));
        }

        public IDataResult<List<User>> GetByFirstName(string FirstName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == FirstName));
        }

        public IDataResult<List<User>> GetByEmail(string Email)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Email == Email));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            
            _userDal.Add(user);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
