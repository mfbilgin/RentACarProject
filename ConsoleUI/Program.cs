using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();
            //ColorTest();
            ///CarTest();

            //ColorAddTest();
            //CarAddTest();
            //BrandAddTest();   

            CarManager carManager = new CarManager(new EFCarDAL());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Adı : "+car.Ad + "\n" + 
                    "Markası : " + car.BrandName + "\n"  +
                    "Rengi : " + car.ColorName + "\n" + 
                    "Günlük Kiralama Bedeli : " + car.DailyPrice + "\n" +
                    "-----------------------------------------");
            }


        }

        private static void BrandAddTest()
        {
            Brand BMW = new Brand();
            BMW.BrandId = 5;
            BMW.BrandName = "BMW";
            EFBrandDAL eFBrandDAL = new EFBrandDAL();
            eFBrandDAL.Add(BMW);
            BrandManager brandManager = new BrandManager(new EFBrandDAL());

            foreach (Brand brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorAddTest()
        {
            Color yellow = new Color();
            yellow.ColorId = 4;
            yellow.ColorName = "Sarı";
            EFColorDAL eFColorDAL = new EFColorDAL();
            eFColorDAL.Add(yellow);
            ColorManager colorManager = new ColorManager(new EFColorDAL());

            foreach (Color color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDAL());
            foreach (Brand brand in brandManager.GetByBrandId(2))
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDAL());
            foreach (Color color in colorManager.GetByColorId(2))
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarAddTest()
        {
            Car product2 = new Car();
            product2.BrandId = 2;
            product2.ColorId = 2;
            product2.DailyPrice = 800;
            product2.Descript = "Beyaz Tesla Model X";
            product2.Id = 10;
            product2.ModelYear = 2020;
            product2.Ad = "";
            EFCarDAL eFCarDAL = new EFCarDAL();
            eFCarDAL.Add(product2);
        }

        private static void CarTest()
        {
            CarManager productManager = new CarManager(new EFCarDAL());
            foreach (Car car in productManager.GetAllByColorId(2))
            {
                Console.WriteLine(car.Descript);
            }
        }
    }
}
