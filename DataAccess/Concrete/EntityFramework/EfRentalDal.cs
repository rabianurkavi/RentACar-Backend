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
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto { CarName = c.CarName, RentalId = r.CarId, CustomerName = cu.CompanyName, RentDate = r.RentDate, ReturnDate = r.ReturnDate, UserName = u.FirstName + " " + u.LastName };

                            
                return result.ToList();


            }
        }
    }
}
