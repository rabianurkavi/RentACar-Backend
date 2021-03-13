using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.ValidationAspect;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(car.CarName));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.delete")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        //[PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            Thread.Sleep(100);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
        [SecuredOperation("Car.List")]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Car>> GetAllByBrand(int brandid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandid).ToList());
        }

        public IDataResult<List<CarDetailsDto>> GetAllCarDetails()
        {
            var result = _carDal.GetAllCarDetails();
            
                return new SuccessDataResult<List<CarDetailsDto>>(result); 
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(P => P.BrandId == id));
        }

        public IDataResult<Car> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(P => P.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsDailyPrice(decimal min)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.DailyPrice>=0));
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }
  
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if(car.CarName.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        private IResult CheckIfProductNameExists(string carName)
        {

            var result = _carDal.GetAll(p => p.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }

            return new SuccessResult();
        }

        

    }
}
