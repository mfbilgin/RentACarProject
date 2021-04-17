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
        IDataResult<Color> GetByColorId(int colorId);
        IDataResult<Color> GetByColorName(string colorName);
        IResult Add(Color color);
        IResult Delete(Color color);

    }
}