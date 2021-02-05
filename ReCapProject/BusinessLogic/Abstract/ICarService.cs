using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
   public  interface ICarService
    {
        Car GetById(Expression<Func<Car, bool>> filter);
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int Id);
        List<Car> GetCarsByColorId(int Id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
