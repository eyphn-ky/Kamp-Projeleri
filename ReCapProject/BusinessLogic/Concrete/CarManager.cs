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
using Core.Utilities.Results;
using BusinessLogic.Constants;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace BusinessLogic.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult("Kayıt başarılı!!");
            
        }

        public IResult Delete(Car car)
        {
           _carDal.Delete(car);
           return new Result(true,"Silme Başarılı");
          
        }

        public IDataResult<List<Car>> GetAll()
        {
            // if(DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
                
        
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public  IDataResult<Car>GetById(Expression<Func<Car, bool>> filter)
        {
          
            return new SuccessDataResult<Car>(_carDal.GetById(filter));
        }

        public IResult Update(Car car)
        {
            if (!(car.DailyPrice > 0))
            {
                return new Result(false, "Günlük ücret belirtilmedi!!");          
            }        
            return new Result(true ,"Araç Eklendi");
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int Id)

        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(p => p.BrandId == Id).ToList());
        }
        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(p => p.ColorId == Id).ToList());
        }

        public IDataResult<List<RentCarDetailsDto>> GetRentCarDetails()
        {
           return new SuccessDataResult<List<RentCarDetailsDto>>(_carDal.GetRentCarDetails());
        }

        public IResult GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(p=>p.Id==id));
        }
    }
}
