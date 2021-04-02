using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal:ICarDal
    {

        List<Car> _products;
        public InMemoryProductDal()
        {
            _products = new List<Car>
            {
                new Car{ Id=1, BrandId=1, ColorId=3, ModelYear=2002, DailyPrice=250, Description="22 yaşından küçükler kiralayamaz."},
                new Car{ Id=2, BrandId=1, ColorId=1, ModelYear=2006, DailyPrice=300, Description="22 yaşından küçükler kiralayamaz."},
                new Car{ Id=3, BrandId=2, ColorId=3, ModelYear=2018, DailyPrice=345, Description="24 yaşından küçükler kiralayamaz."},
                new Car{ Id=4, BrandId=2, ColorId=2, ModelYear=1998, DailyPrice=150, Description="22 yaşından küçükler kiralayamaz."},
                new Car{ Id=5, BrandId=3, ColorId=1, ModelYear=2020, DailyPrice=540, Description="350 km uzaktaki yerlere gidilmeye izin verilmez."},

            };
        }

        public List<Car> GetAll()
        {
            return _products;
        }

        public void Add(Car product)
        {
            _products.Add(product);
        }

        public void Delete(Car product)
        {
            Car productToDelete = null;
            productToDelete = _products.SingleOrDefault(p => p.Id == product.Id);//LİNQ singleordefault tek bir eleman bulmaya yarar (=>Lambda) yukarıdaki foreach yerine bunu kısayol haline getirdik.
            _products.Remove(productToDelete);
        }

        public void Update(Car product)
        {
            Car productToUpdate = null;
            productToUpdate = _products.SingleOrDefault(p => p.Id == product.Id);
            _products.Remove(productToUpdate);
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _products.Where(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _products.Where(p => p.ColorId == colorId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarsDetail(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetAllCarDetailsByFilter(CarDetailFilterDto filter)
        {
            throw new NotImplementedException();
        }
    }
}
