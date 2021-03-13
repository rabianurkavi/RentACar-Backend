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
        IDataResult<Car> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsDailyPrice(decimal min);
        IDataResult<List<Car>> GetAllByBrand(int brandid);
        IDataResult<List<CarDetailsDto>> GetAllCarDetails();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IResult TransactionalOperation(Car car);
    }
}
