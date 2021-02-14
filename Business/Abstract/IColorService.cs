using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetByColorId(int ColorId);
        IDataResult<List<Color>> GetByColorName(string ColorName);
        IResult Add(Color color);
    }
}