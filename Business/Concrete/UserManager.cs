using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDAL.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDAL.Add(user);

        }

        public User GetByMail(string email)
        {
            return _userDAL.Get(u => u.Email == email);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetAll());
        }
    }
}
