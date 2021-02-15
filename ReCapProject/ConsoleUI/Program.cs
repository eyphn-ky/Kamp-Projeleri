using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using Core.Entities;
using Entities.DTOs;
using Core.Utilities.Results;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarTest();
            ColorTest();
            
            int CarId;
            int CustomerId;
            int toReturnCarId;
            int toReturnCustomerId;
            
            //RentCarDetailsTest();
            //RentalDetailsTest(1);
            Console.Write("Kiralamak İstediğiniz Araç Id :");
            CarId = int.Parse(Console.ReadLine());
            Console.Write("Müşteri Numaranız :");
            CustomerId = int.Parse(Console.ReadLine());
            RentACar(CarId,CustomerId);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            Console.Write("Bırakılacak Araç Id :");
            toReturnCarId = int.Parse(Console.ReadLine());
            Console.Write("Müşteri Numarası :");
            toReturnCustomerId = int.Parse(Console.ReadLine());
            rental.CarId = toReturnCarId;
            rental.CustomerId = toReturnCustomerId;
            Console.WriteLine(rentalManager.Update(rental).Message);
            

        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("-- ID : " + car.Id + " " + car.Name + " " + car.ModelYear);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void RentalDetailsTest(int Id)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentalDetailsDto rental = rentalManager.GetAllRentalDetails(Id).Data;
            Console.WriteLine(rental.CarId + " " + rental.Name + " " + rental.CompanyName + " " +
                              rental.CustomerId + " " + rental.FirstName + " " + rental.LastName + " " +
                              rental.RentDate + " " + rental.ReturnDate);

        }
        private static void RentACar(int CarId,int CustomerId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.CarId = CarId;
            rental.CustomerId = CustomerId;
            rental.RentDate = DateTime.Now;
            Console.WriteLine(rentalManager.Add(rental).Message);
        }
        private static void RentCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine();
            foreach (var car in carManager.GetRentCarDetails().Data)
            {
                Console.WriteLine(car.BrandName);
            }
        }

    }
}
