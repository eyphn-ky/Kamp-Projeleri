using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
   public  interface ICarService
    {
        IDataResult<Car>GetById(Expression<Func<Car, bool>> filter);
        IDataResult<List<RentCarDetailsDto>> GetRentCarDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int Id);
        IDataResult<List<Car>> GetCarsByColorId(int Id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

    }
}
