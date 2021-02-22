using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    { /*
        -Buna gerek kalmadı generic sınıf kullanıldı.
        List<Car> GetAll();
        void Add(Car product);
        void Delete(Car product);
        void Update(Car product);

        List<Car> GetAllByBrand(int brandId);//ürünleri kategoriye göre filtrele(listele)
        List<Car> GetAllByColor(int colorId);//ürünleri kategoriye göre filtrele
      */
        List<CarDetailsDto> GetCarDetails();
    }
}
