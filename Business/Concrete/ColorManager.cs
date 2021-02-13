using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(CarColor carColor)
        {
            _colordal.Add(carColor);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(CarColor carColor)
        {
            _colordal.Delete(carColor);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<CarColor>> GetAll()
        {
             return new SuccessDataResult<List<CarColor>>(_colordal.GetAll());
        }

        public IDataResult<CarColor> GetById(int colorid)
        {
            
            return new SuccessDataResult<CarColor>(_colordal.Get(p => p.ColorId == colorid));
        }

       
    }
}
