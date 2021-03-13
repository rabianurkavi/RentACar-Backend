using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomerDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CustomerId=user.Id,
                             };
                  return result.ToList();
            }
        }
    }
}
