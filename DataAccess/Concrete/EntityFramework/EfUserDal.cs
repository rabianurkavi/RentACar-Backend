using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,NorthwindContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from ope in context.OperationClaims
                             join usr in context.UserOperationClaims
                                 on ope.Id equals usr.OperationClaimId
                             where usr.UserId == user.Id
                             select new OperationClaim { Id = ope.Id, Name = ope.Name };
                return result.ToList();

            }
        }

    }
}
