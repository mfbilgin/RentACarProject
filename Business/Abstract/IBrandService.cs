using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetByBrandId(int brandId);
        IDataResult<Brand> GetByBrandName(string brandName);
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
    }
}
