using BusinessLogic.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.IO;
using Core.Utilities.FileHelper;
using System.Linq;
using Core.Utilities.Business;

namespace BusinessLogic.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.DateTime = DateTime.Now;
            carImage.ImagePath = new Guid().ToString();
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +
                _carImageDal.GetById(c => c.Id == carImage.Id).ImagePath;
            IResult result = BusinessRules.Run(FileHelper.Delete(oldPath));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(p=>p.Id==id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.GetById(p=>p.Id==carImage.Id).ImagePath, file);
            carImage.DateTime = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        private IResult CheckIfImageLimitExceeded(int id)
        {
            var carImagecount = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (carImagecount > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, DateTime = DateTime.Now } };
            }
            return _carImageDal.GetAll(c => c.CarId == id);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }
    }
}
