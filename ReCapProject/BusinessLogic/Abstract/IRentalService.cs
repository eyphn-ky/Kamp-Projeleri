using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface IRentalService
    {
       
        IDataResult<Rental> GetById(Expression<Func<Rental, bool>> filter);
        IDataResult<RentalDetailsDto> GetAllRentalDetails(int Id);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
