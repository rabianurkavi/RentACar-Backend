using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(CarBrand carBrand)
        {
            _brandDal.Add(carBrand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(CarBrand carBrand)
        {
            _brandDal.Delete(carBrand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<CarBrand>> GetAll()
        {
            return new SuccessDataResult<List<CarBrand>>(_brandDal.GetAll(),Messages.BrandsListed);
        }

        public IDataResult<CarBrand> GetById(int brandid)
        {
            return new SuccessDataResult<CarBrand>(_brandDal.Get(p => p.BrandId == brandid));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(CarBrand carBrand)
        {
            _brandDal.Update(carBrand);
            return new SuccessResult(Messages.BrandUpdated);
        }
       

    }
}
