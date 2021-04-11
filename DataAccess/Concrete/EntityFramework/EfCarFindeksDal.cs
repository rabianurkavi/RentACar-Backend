using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarFindeksDal
    {
        public List<CarFindeksDetailDto> GetFindeksDetail(Expression<Func<CarFindeksDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.CarFindeks
                             join car in context.Cars on c.CarId equals car.Id
                             select new CarFindeksDetailDto()
                             { CarId = car.Id, FindeksScore = c.FindeksScore, FindeksId = c.Id };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
