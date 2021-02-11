using Business.Abstract;
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
        public List<CarBrand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public CarBrand GetById(int brandid)
        {
            return _brandDal.Get(p => p.BrandId == brandid);
        }
    }
}
