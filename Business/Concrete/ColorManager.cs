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
    public class ColorManager : IColorService
    {
        IColorDAL _colorDAL;
        public ColorManager(IColorDAL colorDAL)
        {
            _colorDAL = colorDAL;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDAL.Add(color);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDAL.Delete(color);
            return new SuccessResult(Messages.deleted);
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
