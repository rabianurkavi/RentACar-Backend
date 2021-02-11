using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             CarText();
            // BrandText();
            Console.ReadKey();
        }

        private static void BrandText()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "/" + brand.BrandName);
            }
        }

        private static void CarText()
        {
            CarManager productManager = new CarManager(new EfCarDal());
            foreach (var product in productManager.GetCarDetails())
            {
                Console.WriteLine(product.CarId+"/"+product.CarName+"/"+product.BrandName+"/"+product.ColorName+"/"+product.DailyPrice);
            }
        }
    }
}
