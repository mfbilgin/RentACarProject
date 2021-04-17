using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public static class Program
    {
        static void Main()
        {

            // GetAllRentalTest();
            // GetAllCarTest();
            //
            // CarDetailTest();
            //
            //
            // ColorAddTest();
            // BrandAddTest();
            // CarAddTest();
            // CustomerAddTest();
            // RentalAddTest(4, 1);
            // RentalAddTest(7,3);
            // RentalAddTest(2,4);
            // GetAllRentalTest();
            // RentalUpdate(1);
            // GetRentalByRentalId(1);


        }

        private static void GetAllCarTest()
        {

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("Araç Id'si : "+car.CarId);
                Console.WriteLine("Araç Marka Id'si : "+car.BrandId);
                Console.WriteLine("Araç Marka Adı : "+car.BrandName);
                Console.WriteLine("Araç Renk Id'si : "+car.ColorId);
                Console.WriteLine("Araç Günlük Fiyatı : "+car.DailyPrice);
                Console.WriteLine("Araç Marka ve Modeli : "+car.Descript);
                Console.WriteLine("Araç Model Yılı: "+car.ModelYear);
                Console.WriteLine("Araç İçin Gerekli Findex Puanı : "+car.MinFindex);
                Console.WriteLine("------------------------------------------------------");


            }
        }

        static void BrandAddTest(string brandName)
        {
            Brand brand = new Brand {BrandName = brandName};
            BrandManager brandManager = new BrandManager(new EfBrandDal());
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
            Color color = new Color {ColorName = colorName};
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(color);

            GetAllColorTest();
        }

        static void CarAddTest(int brandId, int colorId, int dailyPrice, string descript, int modelYear, string ad)
        {
   
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car
            {
                BrandId = brandId,
                ColorId = colorId,
                DailyPrice = dailyPrice,
                Descript = descript,
                ModelYear = modelYear,
                BrandName = ad
            };
            carManager.Add(car);

            GetAllCarTest();
        }

        static void RentalAddTest(int carId, int customerId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental {CarId = carId, CustomerId = customerId};
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

        static void CustomerAddTest(int userId, string companyName)
        {
            Customer customer = new Customer {CompanyName = companyName, UserId = userId};
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer);

            GetAllCustomerTest();
        }
        private static void RentalUpdate(int rentalId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetById(rentalId).Data;
           
                EfRentalDal rentalDal = new EfRentalDal();
                Rental rental = new Rental
                {
                    CarId = result.CarId,
                    CustomerId = result.CustomerId,
                    UserId = result.UserId,
                    RentalId = rentalId,
                    RentDate = result.RentDate,
                    ReturnDate = DateTime.Now
                };
                rentalDal.Update(rental);
            
        }

        private static void GetAllBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
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
                if (rental.ReturnDate == null || rental.ReturnDate > DateTime.Now)
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
            ColorManager colorManager = new ColorManager(new EfColorDal());
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
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
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
            var rental = rentalManager.GetById(rentalId).Data;
          
            Console.WriteLine("Kiralama Id'si : " + rental.RentalId);
            Console.WriteLine("Kiralanan Araba Id'si : " + rental.CarId);
            Console.WriteLine("Kiralayan Müşteri Id'si : " + rental.CustomerId);
            Console.WriteLine("Kiralama Tarihi : " + rental.RentDate);
            Console.WriteLine("Teslim Tarihi : " + rental.ReturnDate);
            Console.WriteLine("--------------------------------");
            
        }

        static void CarDetailTest()
        {

            CarManager carManager = new CarManager(new EfCarDal());
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
