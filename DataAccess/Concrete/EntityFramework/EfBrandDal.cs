using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(CarBrand entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(CarBrand entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public CarBrand Get(Expression<Func<CarBrand, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<CarBrand>().SingleOrDefault(filter);
            }
        }

        public List<CarBrand> GetAll(Expression<Func<CarBrand, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //veri tabanındaki bütün tabloyu listeye çevir onu bana ver- select * from cars döndürüyor(sqlde)
                return filter == null ? context.Set<CarBrand>().ToList()
                    : context.Set<CarBrand>().Where(filter).ToList();

            }
        }

        public void Update(CarBrand entity)
        {
            throw new NotImplementedException();
        }
    }
}
