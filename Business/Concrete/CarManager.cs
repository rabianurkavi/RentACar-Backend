using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();

        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(P => P.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(P => P.ColorId == id);
        }

        public List<Car> SetCarsDailyPrice(decimal min)
        {
            return _carDal.GetAll(p=>p.DailyPrice>=0);
        }
    }
}
