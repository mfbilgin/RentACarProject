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
    public class ColorManager : IColorService
    {
        IColorDAL _colorDAL;
        public ColorManager(IColorDAL colorDAL)
        {
            _colorDAL = colorDAL;
        }

        public IResult Add(Color color)
        {
            if(color.ColorName == null || color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDAL.Add(color);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll());
        }

        public IDataResult<List<Color>> GetByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll(c => c.ColorId == ColorId));
        }

        public IDataResult<List<Color>> GetByColorName(string ColorName)
        {
            return new SuccessDataResult<List< Color >> (_colorDAL.GetAll(c => c.ColorName == ColorName));
        }
    }
}
