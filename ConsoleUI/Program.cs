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
             //CarText();
             //BrandText();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var data in result.Data)
            {
                Console.WriteLine(data.CarName );
            }
            Console.ReadKey();
        }

        private static void BrandText()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "/" + brand.BrandName);
            }
        }
        
        private static void CarText()
        {
            CarManager productManager = new CarManager(new EfCarDal());
            foreach (var product in productManager.GetCarDetails().Data)
            {
                Console.WriteLine(product.CarId+"/"+product.CarName+"/"+product.BrandName+"/"+product.ColorName+"/"+product.DailyPrice);
            }
        }
    }
}
