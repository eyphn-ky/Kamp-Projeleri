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
      
            ICarService carManager= new CarManager(new EfCarDal());
          
            IBrandService brandManager = new BrandManager( new EfBrandDal());
            
            

            List<Car> cars = carManager.GetAll();
            foreach(var item in cars)
            {
                Console.WriteLine(item.DailyPrice);
            }

            Car vehicle = new Car { Id = 3 ,BrandId=3,ColorId=3, Description="Miyav",ModelYear="2020",DailyPrice=20m};
            carManager.Update((Car)vehicle);
            Console.WriteLine("\n");
           
            List<RentCarDetailsDto> details =carManager.GetRentCarDetails();
            foreach(var item in details)
            {
                Console.WriteLine(" Marka : "+item.BrandName+" Renk : "+item.ColorName+
                    " Model Yılı : "+item.ModelYear +" Günlük Ücret : "+item.DailyPrice);
            }









            int i = 3;
            List<Car> cars1 = carManager.GetCarsByBrandId(i);
            foreach(var item in cars1)
            {
                
                Console.WriteLine("Id'si "+i+" olan araca ait bilgiler - Araç Kayıt Numarası : "+item.Id+" Araç Renk Numarası : "+item.ColorId+" Araç Marka Numarası : "+
                    item.BrandId+ " Araç Model Yılı :  " + item.ModelYear+" Araç Açıklama : "+item.Description);
            }



            Console.ReadLine();
        }
    }
}
