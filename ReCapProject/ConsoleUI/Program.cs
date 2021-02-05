using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDal carDal = new EfCarDal();
            ICarService carManager= new CarManager(carDal);
            IBrandDal brandDal = new EfBrandDal();
            IBrandService brandManager = new BrandManager(brandDal);
            
            

            List<Car> cars = carManager.GetAll();
            foreach(var item in cars)
            {
                Console.WriteLine(item.DailyPrice);
            }

            IEntity vehicle = new Car { Id = 3 ,BrandId=3,ColorId=3, Description="Miyav",ModelYear="2020",DailyPrice=20m};
            carManager.Update((Car)vehicle);

            List<Car> cars2 = carManager.GetAll();
            foreach (var item in cars2)
            {
                Console.WriteLine(item.DailyPrice);
            }
            Car car = new Car {
                BrandId = 5, ColorId = 5, DailyPrice = 0, Description = "Ben 20 yaşıma girdimm", ModelYear = "2000"
            };
            carManager.Add(car);


           
            Brand brand = new Brand { 
              Name="LADA"
            };
            brandManager.Add(brand);
            Console.WriteLine(car.ModelYear);
            List<Car> cars1 = carManager.GetCarsByBrandId(3);
            foreach(var item in cars1)
            {
                Console.WriteLine(item.Id+" "+item.ColorId+" "+item.BrandId+" "+item.ModelYear+" "+item.Description);
            }



            Console.ReadLine();
        }
    }
}
