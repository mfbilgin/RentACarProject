using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{
    public interface ICarDAL : IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetail(int carId);
    }
}
