using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetByBrandId(int BrandId);
        IDataResult<List<Brand>> GetByBrandName(string BrandName);
        IResult Add(Brand brand);
    }
}
