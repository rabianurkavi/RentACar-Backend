using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join b in context.Brands
                             on car.BrandId equals b.BrandId

                             join cus in context.Customers
                             on rental.CustomerId equals cus.Id

                             join us in context.Users
                             on cus.UserId equals us.Id

                             select new RentalDetailDto
                             {
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 CompanyName = cus.CompanyName,
                                 BrandName = b.BrandName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 CarName=car.CarName

                             };


                return result.ToList();


            }
        }
    }
}
