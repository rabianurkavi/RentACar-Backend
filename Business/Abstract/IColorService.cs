using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<CarColor>> GetAll();
        IDataResult<CarColor> GetById(int colorid);
        IResult Add(CarColor carColor);
        IResult Delete(CarColor carColor);
       
    }
}
