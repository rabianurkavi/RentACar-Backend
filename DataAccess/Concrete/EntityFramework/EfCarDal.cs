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
                                 ModelYear = car.ModelYear,
                                 CarName=car.CarName
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
        public List<CarDetailsDto> GetAllCarDetailsByFilter(CarDetailFilterDto filterDto)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var filterExpression = GetFilterExpression(filterDto);
                var result = from car in filterExpression == null ? context.Cars : context.Cars.Where(filterExpression)
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join carImage in context.CarImages on car.Id equals carImage.CarId
                             select new CarDetailsDto
                             {
                                 CarId = car.Id,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 ImagePath = carImage.ImagePath,
                                 ModelYear = car.ModelYear,
                                 BrandName = brand.BrandName,
                                 Description = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList(); // tolist yapmadan query'e dönüştürüp verileri çekmez.

            }
        }


    }
}
