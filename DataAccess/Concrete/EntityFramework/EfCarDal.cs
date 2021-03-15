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
        public List<CarDetailsDto> GetAllCarDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join e in context.Brands
                             on p.BrandId equals e.BrandId
                             select new CarDetailsDto { CarId = p.Id, BrandName = e.BrandName, ColorName = c.ColorName, DailyPrice = p.DailyPrice, ModelYear=p.ModelYear };
                return result.ToList();

            }
        }
        public List<CarDetailsDto> GetCarsDetail(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join carImage in context.CarImages on car.Id equals carImage.CarId
                             select new CarDetailsDto()
                             {
                                 CarId = car.Id,
                                 ImagePath = carImage.ImagePath,
                                 Description = car.Description,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,
                                 CarImageDate = carImage.Date,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        
    }
}
