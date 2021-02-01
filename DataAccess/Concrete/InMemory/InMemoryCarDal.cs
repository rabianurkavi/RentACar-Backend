using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{ ProductId=1, BrandId=1, ColorId=3, ModelYear=2002, DailyPrica=250, Description="22 yaşından küçükler kiralayamaz."},
                new Car{ ProductId=2, BrandId=1, ColorId=1, ModelYear=2006, DailyPrica=300, Description="22 yaşından küçükler kiralayamaz."},
                new Car{ ProductId=3, BrandId=2, ColorId=3, ModelYear=2018, DailyPrica=345, Description="24 yaşından küçükler kiralayamaz."},
                new Car{ ProductId=4, BrandId=2, ColorId=2, ModelYear=1998, DailyPrica=150, Description="22 yaşından küçükler kiralayamaz."},
                new Car{ ProductId=5, BrandId=3, ColorId=1, ModelYear=2020, DailyPrica=540, Description="350 km uzaktaki yerlere gidilmeye izin verilmez."},

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
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//LİNQ singleordefault tek bir eleman bulmaya yarar (=>Lambda) yukarıdaki foreach yerine bunu kısayol haline getirdik.
            _products.Remove(productToDelete);
        }

        public void Update(Car product)
        {
            Car productToUpdate = null;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
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

        
    }
}
