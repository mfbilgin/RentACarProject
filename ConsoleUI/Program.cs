using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDAL());

            foreach (var car in productManager.GetAll())
            {
                Console.WriteLine(car.Description);
                Console.WriteLine("Üretim Yılı : " + car.ModelYear);
                Console.WriteLine("Günlük Kiralama Bedeli : " + car.DailyPrice);
                Console.WriteLine("----------------------------");
            }
            
        }
    }
}
