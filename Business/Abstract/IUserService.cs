using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByUserId(int UserId);
        IDataResult<List<User>> GetByFirstName(string FirstName);
        IDataResult<List<User>> GetByEmail(string Email);
        IResult Add(User user);
    }
}
