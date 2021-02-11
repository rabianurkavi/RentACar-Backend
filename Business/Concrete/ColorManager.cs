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
        IColorDal _colordal;
        public ColorManager(IColorDal colorDal)
        {
            _colordal = colorDal;
        }
        public List<CarColor> GetAll()
        {
            return _colordal.GetAll();
        }

        public CarColor GetById(int colorid)
        {
            return _colordal.Get(p => p.ColorId == colorid);
        }
    }
}
