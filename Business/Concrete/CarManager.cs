using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _productDal;
        public CarManager(ICarDal productDal)
        {
            _productDal = productDal;
        }
        
        public List<Car> GetAll()
        {
            return _productDal.GetAll();
        }
    }
}
