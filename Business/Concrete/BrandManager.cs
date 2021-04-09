using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDAL.Add(brand);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDAL.Delete(brand);
            return new SuccessResult(Messages.deleted);
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
