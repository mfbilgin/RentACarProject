using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<OperationClaim>> GetClaimById(int userId);
        IDataResult<List<User>> GetByEmail(string email);
        IDataResult<User> GetByUserId(int userId);
        void Add(User user);
        IResult Update(User user);
        User GetByMail(string email);
        IResult AddFindexPoint(int userId);

    }
}
