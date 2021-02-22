using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join e in context.Brands
                             on p.BrandId equals e.BrandId
                             select new CarDetailsDto { CarId = p.Id, CarName = p.CarName, BrandName = e.BrandName, ColorName = c.ColorName, DailyPrice = p.DailyPrice };
                return result.ToList();

            }
        }
    }
}
