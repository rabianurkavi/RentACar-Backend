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
    public class EfFindeksDal : EfEntityRepositoryBase<Findeks, NorthwindContext>, IFindeksDal
    {
        public List<FindeksDetailDto> GetFindeksDetail(Expression<Func<FindeksDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from f in context.Findeks
                             join u in context.Users on f.UserId equals u.Id
                             select new FindeksDetailDto()
                             {
                                 FindeksId = f.Id,
                                 UserId = u.Id,
                                 UserName = u.FirstName + " " + u.LastName,
                                 FindeksScore = f.FindeksScore

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
