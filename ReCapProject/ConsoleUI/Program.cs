using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDal carDal = new InMemoryCarDal();


            List<Car> cars = carDal.GetAll();
            foreach(var item in cars)
            {
                Console.WriteLine(item.DailyPrice);
            }

            IVehicle vehicle = new Car { Id = 20 ,DailyPrice=300m};
            carDal.Update((Car)vehicle);

            foreach (var item in cars)
            {
                Console.WriteLine(item.DailyPrice);
            }


        }
    }
}
