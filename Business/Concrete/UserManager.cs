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
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDAL.Get(user => user.Email == email));
        }

        public IDataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDAL.Get(user => user.UserId == userId));
        }
        public void Add(User user)
        {
            _userDAL.Add(user);

        }
        public IResult Update(User user)
        {
            _userDAL.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public User GetByMail(string email)
        {
            return _userDAL.Get(u => u.Email == email);
        }

        public IResult AddFindexPoint(int userId)
        {
            var result = GetByUserId(userId);
            
                if (result.Data.FindexPoint < 1900)
                {
                    result.Data.FindexPoint += 20;
                    Update(result.Data);
                }
                else
                {
                    return new ErrorResult(Messages.FindexPointMax);
                }

            
            return new SuccessResult(Messages.FindexPointAdd);

        }
        
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetAll());
        }

        public IDataResult<List<OperationClaim>> GetClaimById(int userId)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDAL.GetClaimById(userId));
        }
    }
}
