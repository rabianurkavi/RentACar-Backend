using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailsDto>> GetCarsByColorId(int colorid);
        IDataResult<List<Car>> GetCarsDailyPrice(decimal min);
        IDataResult<List<CarDetailsDto>> GetCarsDetailByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByModelYear(short min, short max);
        IDataResult<List<CarDetailsDto>> GetCarDetail(int carId);

        IResult TransactionalOperation(Car car);
    }
}
