using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDAL _brandDAL;
        public BrandManager(IBrandDAL brandDAL)
        {
            _brandDAL = brandDAL;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName == null || brand.BrandName.Length <2 )
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _brandDAL.Add(brand);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDAL.GetAll());
        }

        public IDataResult<List<Brand>> GetByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDAL.GetAll(b => b.BrandId == BrandId));
        }

        public IDataResult<List<Brand>> GetByBrandName(string BrandName)
        {
            return new SuccessDataResult<List<Brand>>(_brandDAL.GetAll(b => b.BrandName == BrandName));
        }
    }
}
