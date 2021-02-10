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
            CarManager productManager = new CarManager(new EfCarDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ModelYear);
            }
            Console.ReadKey();
        }
    }
}
