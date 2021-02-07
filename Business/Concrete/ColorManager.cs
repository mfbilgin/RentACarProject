using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDAL _colorDAL;
        public ColorManager(IColorDAL colorDAL)
        {
            _colorDAL = colorDAL;
        }
        public List<Color> GetAll()
        {
            return _colorDAL.GetAll();
        }

        public List<Color> GetByColorId(int ColorId)
        {
            return _colorDAL.GetAll(c => c.ColorId == ColorId);
        }

        public List<Color> GetByColorName(string ColorName)
        {
            return _colorDAL.GetAll(c => c.ColorName == ColorName);
        }
    }
}
