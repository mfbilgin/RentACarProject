using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using Microsoft.IdentityModel.Tokens;
using Core.Entities.Concrete;
using System.Globalization;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            //GetAllRentalTest();
            //GetAllCarTest();

            //CarDetailTest();
            //UserGetAllTest();

            //ColorAddTest();
            //BrandAddTest();
            //CarAddTest();
            //UserAddTest();
            //CustomerAddTest();
            //RentalAddTest(4, 1);
            //RentalAddTest(7,3);
            //RentalAddTest(2,4);
            //GetAllRentalTest();
            //RentalUpdate(1);
            //GetRentalByRentalId(1);


        }

        private static void GetAllCarTest()
        {
            CarManager carManager = new CarManager(new EFCarDAL());
            var result = carManager.GetAll();
            foreach (Car car in result.Data)
            {
                Console.WriteLine("Araç Id'si : " + car.CarId);
                Console.WriteLine("Araç Adı : " + car.Descript);
                Console.WriteLine("Araç Günlük Kiralam Bedeli : " + car.DailyPrice);
                Console.WriteLine("Araç Model : " + car.ModelYear);
                Console.WriteLine("--------------------------------");
            }
        }

        static void BrandAddTest(string brandName)
        {
            Brand brand = new Brand();
            brand.BrandName = brandName;
            BrandManager brandManager = new BrandManager(new EFBrandDAL());
            brandManager.Add(brand);
            var result = brandManager.GetAll();
            foreach (Brand b in result.Data)
            {
                Console.WriteLine(b.BrandName);
            }

            GetAllBrandTest();
        }

        

        private static void ColorAddTest(string colorName)
        {
            Color color = new Color();
            color.ColorName = colorName;
            ColorManager colorManager = new ColorManager(new EFColorDAL());
            colorManager.Add(color);

            GetAllColorTest();
        }

        static void CarAddTest(int brandId, int colorId, int dailyPrice, string descript, int modelYear, string ad)
        {
            Car car = new Car();
            CarManager carManager = new CarManager(new EFCarDAL());
            car.BrandId = brandId;
            car.ColorId = colorId;
            car.DailyPrice = dailyPrice;
            car.Descript = descript;
            car.ModelYear = modelYear;
            car.BrandName = ad;
            carManager.Add(car);

            GetAllCarTest();
        }

        static void RentalAddTest(int carId, int customerId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.CarId = carId;
            rental.CustomerId = customerId;
            rentalManager.Add(rental);

            GetAllRentalTest();
        }

        //static void UserAddTest(string firstName, string lastName, string Email, string password)
        //{
        //    User user = new User();
        //    user.FirstName = firstName;
        //    user.LastName = lastName;
        //    user.Email = Email;
        //    user.Passwrd = password;
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(user);

        //    UserGetAllTest();
        //}

        static void CustomerAddTest(int UserId, string CompanyName)
        {
            Customer customer = new Customer();
            customer.CompanyName = CompanyName;
            customer.UserId = UserId;
            CustomerManager customerManager = new CustomerManager(new EFCustomerDAL());
            customerManager.Add(customer);

            GetAllCustomerTest();
        }
        private static void RentalUpdate(int rentalId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var data = rentalManager.GetById(rentalId).Data;
            foreach (Rental r in data)
            {
                EfRentalDal rentalDal = new EfRentalDal();
                Rental rental = new Rental();
                rental.CarId = r.CarId;
                rental.CustomerId = r.CustomerId;
                rental.UserId = r.UserId;
                rental.RentalId = rentalId;
                rental.RentDate = r.RentDate;
                rental.ReturnDate = DateTime.Now;
                rentalDal.Update(rental);
            }
        }

        private static void GetAllBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDAL());
            var result = brandManager.GetAll();
            foreach (Brand brand in result.Data)
            {
                Console.WriteLine("Marka Id'si : " + brand.BrandId);
                Console.WriteLine("Marka Adı : " + brand.BrandName);
                Console.WriteLine("------------------");
            }
        }

        private static void GetAllRentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine("Kiralama Id'si : " + rental.RentalId);
                Console.WriteLine("Müşteri Id'si : " + rental.CustomerId);
                Console.WriteLine("Kiralanan Araba Id'si : " + rental.CarId);
                Console.WriteLine("Kiralama Tarihi : " + rental.RentDate);
                if (rental.ReturnDate == null)
                {
                    Console.WriteLine("Teslim Tarihi : Araç Henüz Teslim Edilmemiş");
                }
                else
                {
                    Console.WriteLine("Teslim Tarihi : " + rental.ReturnDate);
                }

                Console.WriteLine("----------------------------------------");
            }
        }
        private static void GetAllColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDAL());
            var result = colorManager.GetAll();
            foreach (Color color in result.Data)
            {
                Console.WriteLine("Renk Id'si : " + color.ColorId);
                Console.WriteLine("Renk Adı : " + color.ColorName);
                Console.WriteLine("------------------");
            }
        }

        //static void UserGetAllTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    var result = userManager.GetAll();
        //    foreach (User user in result.Data)
        //    {
        //        Console.WriteLine("Kullanıcı Id'si : " + user.UserId);
        //        Console.WriteLine("İsim : " + user.FirstName);
        //        Console.WriteLine("Soyisim : " + user.LastName);
        //        Console.WriteLine("Email : " + user.Email);
        //    }
        //}

        private static void GetAllCustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EFCustomerDAL());
            var result = customerManager.GetAll();
            foreach (Customer customer in result.Data)
            {
                Console.WriteLine("Kullanıcı Id'si : " + customer.UserId);
                Console.WriteLine("Müşteri Id'si : " + customer.CompanyName);
                Console.WriteLine("Şirket Adı : " + customer.CompanyName);
                Console.WriteLine("---------------------------------");

            }
        }

        private static void GetRentalByRentalId(int rentalId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var data = rentalManager.GetById(rentalId).Data;
            foreach (Rental rental in data)
            {
                Console.WriteLine("Kiralama Id'si : " + rental.RentalId);
                Console.WriteLine("Kiralanan Araba Id'si : " + rental.CarId);
                Console.WriteLine("Kiralayan Müşteri Id'si : " + rental.CustomerId);
                Console.WriteLine("Kiralama Tarihi : " + rental.RentDate);
                Console.WriteLine("Teslim Tarihi : " + rental.ReturnDate);
                Console.WriteLine("--------------------------------");
            }
        }

        static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EFCarDAL());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine("Markası : " + car.BrandName + "\n" +
                                  "Rengi : " + car.ColorName + "\n" +
                                  "Günlük Kiralama Bedeli : " + car.DailyPrice + "\n" +
                                  "-----------------------------------------");
            }
        }

    }
}
