using BusinessLogic.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using System.Linq.Expressions;
using System.Linq;
using Entities.DTOs;

namespace BusinessLogic.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Kayıt başarılı!!");
            }
            else
            {
                Console.WriteLine("Günlük ücret belirtilmedi!!");
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            return _carDal.GetById(filter);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Kayıt başarılı!!");
            }
            else
            {
                Console.WriteLine("Günlük ücret belirtilmedi!!");
            }
        }
        public List<Car> GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll().Where(p => p.BrandId == Id).ToList();
        }
        public List<Car> GetCarsByColorId(int Id)
        {
            return _carDal.GetAll().Where(p => p.ColorId == Id).ToList();
        }

        public List<RentCarDetailsDto> GetRentCarDetails()
        {
           return _carDal.GetRentCarDetails();
        }
    }
}
