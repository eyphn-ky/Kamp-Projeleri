using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=10,BrandId=1,ColorId=43,DailyPrice=150m,Description="Sportif tasarımıyla işlerinizi hızlı bir şekilde halledin",ModelYear="2016"},
                new Car {Id=20,BrandId=2,ColorId=90,DailyPrice=180m,Description="Konforlu tasarımıyla uzun yolculuklar için ideal",ModelYear="2018"},
                new Car {Id=30,BrandId=3,ColorId=120,DailyPrice=200m,Description="Şık tasarımıyla havanızı atın",ModelYear="2020"},
                new Car {Id=40,BrandId=4,ColorId=34,DailyPrice=120m,Description="Sınıfındaki en ekonomik araç",ModelYear="2013"},

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault (p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }
        
        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;            
        }   

       

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

      
    }
}
