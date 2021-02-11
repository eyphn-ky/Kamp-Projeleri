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

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarTest();
            Console.ReadLine();
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach(var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);   
            }
        }

    }
}
