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
        //[SecuredOperation("car.add")]
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
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            Thread.Sleep(1000);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
        //[SecuredOperation("Car.List")]
        
        //public IDataResult<List<Car>> GetAllByBrand(int brandid)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandid));
        //}

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            var result = _carDal.GetCarsDetail();
            
                return new SuccessDataResult<List<CarDetailsDto>>(result,Messages.CarsListed); 
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetail(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetail(cardetail => cardetail.CarId == carId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByModelYear(short min, short max)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetail(
                cardetail => cardetail.ModelYear <= min && cardetail.ModelYear >= max));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(P => P.BrandId == id));
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByColorId(int colorid)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetail(P => P.ColorId == colorid));
        }

        public IDataResult<List<Car>> GetCarsDailyPrice(decimal min)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.DailyPrice>=0));
        }

        public IDataResult<List<CarDetailsDto>> GetCarsDetailByBrandId(int brandId)
        {
            List<CarDetailsDto> carDetails = _carDal.GetCarsDetail(p => p.BrandId == brandId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailsDto>>("");
            }
            else
            {
                return new SuccessDataResult<List<CarDetailsDto>>(carDetails, "");
            }
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }
  
        //[SecuredOperation("admin")]
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
        public IDataResult<List<CarDetailsDto>> GetCarsFiltreDetails(CarDetailFilterDto filterDto)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetAllCarDetailsByFilter(filterDto));
        }




    }
}
