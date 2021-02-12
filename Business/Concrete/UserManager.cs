using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Business.Abstract;
using Business.Constants;
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

        public IResult Add(User user)
        {
            if (user.Email == null)
            {
                Console.WriteLine("Email Adresini Girdiğinizden Emin Olunuz!");
            }
            else if (user.FirstName == null && user.FirstName.Length > 1)
            {
                Console.WriteLine("Lütfen Karakterden Uzun Bir İsim  Girdiğinizden Emin Olunuz!");
            }
            else if (user.LastName == null)
            {
                Console.WriteLine("Lütfen Soyisim Girdiğinizden Emin Olunuz!");
            }
            else if (user.Passwrd == null)
            {
                Console.WriteLine("Lütfen Parola Belirlediğinizden Emin Olunuz!");
            }
            _userDal.Add(user);
            Console.WriteLine("Kullanıcı Eklendi.");
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
