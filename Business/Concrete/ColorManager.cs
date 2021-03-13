using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.ValidationAspect;
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
        [ValidationAspect(typeof(ColorValidator))]
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
             return new SuccessDataResult<List<CarColor>>(_colordal.GetAll(),Messages.ColorsListed);
        }

        public IDataResult<CarColor> GetById(int colorid)
        {
            
            return new SuccessDataResult<CarColor>(_colordal.Get(p => p.ColorId == colorid));
        }

        public IResult Update(CarColor carColor)
        {
            _colordal.Update(carColor);
            return new SuccessResult(Messages.ColorUpdated);
        }

    }
}
