using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerCardDal : EfEntityRepositoryBase<CustomerCard, NorthwindContext>, ICustomerCreditCardDal
    {
    }
}
