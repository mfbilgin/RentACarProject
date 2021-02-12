using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {




            //Customer customer = new Customer();
            //customer.CompanyName = "KodlamaIO";
            //customer.UserId = 1;
            //User user = new User();
            //CustomerManager customerManager = new CustomerManager(new EFCustomerDAL());
            //customerManager.Add(customer,user);


            //BrandTest
            //ColorTest();
            //CarTest();
            //CarDetailTest();
            //CustomerDetailTest();
            //UserGetAllTest();
            //ColorAddTest();
            //CarAddTest(); 
            //BrandAddTest();
        }
        static void RentalUpdate(int carID, int customerID, int rentalId, DateTime rentDate, DateTime returnDate)
        {
            EfRentalDal rentalDal = new EfRentalDal();
            Rental rental = new Rental();
            rental.CarId = carID;
            rental.CustomerId = customerID;
            rental.RentalId = rentalId;
            rental.RentDate = rentDate;
            rental.ReturnDate = returnDate;
            rentalDal.Update(rental);
        }
        static void RentalAddTest(int carId, int customerId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.CarId = carId;
            rental.CustomerId = customerId;
            rental.RentDate = DateTime.Now;
            rentalManager.Add(rental);
        }
        static void CustomerUpdate(int customerId, string companyName, int userId)
        {
            EFCustomerDAL customerDal = new EFCustomerDAL();
            Customer customer = new Customer();
            customer.CustomerId = customerId;
            customer.CompanyName = companyName;
            customer.UserId = userId;
            customerDal.Update(customer);
        }
        static void UserGetAllTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (User user in result.Data)
            {
                Console.WriteLine("Kullanıcı Id'si : " + user.UserId);
                Console.WriteLine("İsim : " + user.FirstName);
                Console.WriteLine("Soyisim : " + user.LastName);
                Console.WriteLine("Email : " + user.Email);
                Console.WriteLine("---------------------------------");
            }
        }
        static void UserAddTest(string firstName, string lastName, string Email, string password)
        {
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = Email;
            user.Passwrd = password;
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(user);

            UserGetAllTest();
        }
        static void CustomerAddTest(int UserId, string CompanyName)
        {
            Customer customer = new Customer();
            customer.CompanyName = CompanyName;
            customer.UserId = UserId;
            CustomerManager customerManager = new CustomerManager(new EFCustomerDAL());
            customerManager.Add(customer);
        }
        static void CustomerDeleteTest()
        {
            Customer customer = new Customer();
            customer.CustomerId = 1;
            ICustomerDAL customerDal = new EFCustomerDAL();
            customerDal.Delete(customer);
        }

        static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EFCarDAL());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine("Adı : " + car.Ad + "\n" +
                                  "Markası : " + car.BrandName + "\n" +
                                  "Rengi : " + car.ColorName + "\n" +
                                  "Günlük Kiralama Bedeli : " + car.DailyPrice + "\n" +
                                  "-----------------------------------------");
            }

            static void BrandAddTest()
            {
                Brand BMW = new Brand();
                BMW.BrandId = 5;
                BMW.BrandName = "BMW";
                EFBrandDAL eFBrandDAL = new EFBrandDAL();
                eFBrandDAL.Add(BMW);
                BrandManager brandManager = new BrandManager(new EFBrandDAL());
                var result = brandManager.GetAll();
                foreach (Brand brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }

            static void ColorAddTest()
            {
                Color yellow = new Color();
                yellow.ColorId = 4;
                yellow.ColorName = "Sarı";
                EFColorDAL eFColorDAL = new EFColorDAL();
                eFColorDAL.Add(yellow);
                ColorManager colorManager = new ColorManager(new EFColorDAL());
                var result = colorManager.GetAll();
                foreach (Color color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }

            static void BrandTest()
            {
                BrandManager brandManager = new BrandManager(new EFBrandDAL());
                var result = brandManager.GetByBrandId(2);
                foreach (Brand brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }

            static void ColorTest()
            {
                ColorManager colorManager = new ColorManager(new EFColorDAL());
                var result = colorManager.GetByColorId(2);
                foreach (Color color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }

            static void CarAddTest()
            {
                Car product2 = new Car();
                product2.BrandId = 2;
                product2.ColorId = 2;
                product2.DailyPrice = 800;
                product2.Descript = "Beyaz Tesla Model X";
                product2.CarId = 10;
                product2.ModelYear = 2020;
                product2.Ad = "";
                EFCarDAL eFCarDAL = new EFCarDAL();
                eFCarDAL.Add(product2);
            }

            static void CarTest()
            {
                CarManager productManager = new CarManager(new EFCarDAL());
                var result = productManager.GetAllByColorId(2);
                foreach (Car car in result.Data)
                {
                    Console.WriteLine(car.Descript);
                }
            }
        }
    }
}
