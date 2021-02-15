using BusinessLogic.Abstract;
using BusinessLogic.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
namespace BusinessLogic.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            RentalDetailsDto rentalDetails = _rentalDal.GetRentalDetails(rental.CarId);
            if (rentalDetails==null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.SuccessRental);
            }
            else if(int.Parse(rentalDetails.ReturnDate.Year.ToString()) > 2000 && rentalDetails.Id>0)
            {
                _rentalDal.Add(rental); 
                return new SuccessResult(Messages.SuccessRental);
            }
            else
            {
                return new ErrorResult(Messages.CanNotRent);
            }
            
           
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
          
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<RentalDetailsDto> GetAllRentalDetails(int Id)
        {
            return new SuccessDataResult<RentalDetailsDto>(_rentalDal.GetRentalDetails(Id));
        }

        public IDataResult<Rental> GetById(Expression<Func<Rental, bool>> filter)
        {
           
            return new SuccessDataResult<Rental> (_rentalDal.GetById(filter));
        }

        public IResult Update(Rental rental)
        {
            RentalDetailsDto toUpdate=_rentalDal.GetRentalDetails(rental.CarId);
            rental.CustomerId = toUpdate.CustomerId;
            rental.RentDate = toUpdate.RentDate;
            rental.ReturnDate = DateTime.Now;
            rental.Id = toUpdate.Id;
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdateSuccesful);
        }

    }
}
