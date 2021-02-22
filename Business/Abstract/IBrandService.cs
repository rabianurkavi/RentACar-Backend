using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<CarBrand>> GetAll();
        IDataResult<CarBrand> GetById(int brandid);
        IResult Add(CarBrand carBrand);
        IResult Delete(CarBrand carBrand);
        IResult Update(CarBrand carBrand);
    }
}
