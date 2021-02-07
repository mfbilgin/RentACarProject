using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDAL _brandDAL;
        public BrandManager(IBrandDAL brandDAL)
        {
            _brandDAL = brandDAL;
        }
        public List<Brand> GetAll()
        {
            return _brandDAL.GetAll();
        }

        public List<Brand> GetByBrandId(int BrandId)
        {
            return _brandDAL.GetAll(b => b.BrandId == BrandId);
        }

        public List<Brand> GetByBrandName(string BrandName)
        {
            return _brandDAL.GetAll(b => b.BrandName == BrandName);
        }
    }
}
