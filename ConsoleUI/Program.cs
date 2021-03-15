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
             BrandText();
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.GetRentalDetails();
            //foreach (var data in result.Data)
            //{
            //    Console.WriteLine(data.CarName );
            //}
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CompanyName);
            }
            Console.ReadKey();
        }

        private static void BrandText()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if(result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine( "/" + brand.BrandName);
                }
            }
           
        }
        
        private static void CarText()
        {
            CarManager productManager = new CarManager(new EfCarDal());
            foreach (var product in productManager.GetCarsDetails().Data)
            {
                Console.WriteLine(product.CarId+"/"+product.CarName+"/"+product.BrandName+"/"+product.ColorName+"/"+product.DailyPrice);
            }
        }
    }
}
