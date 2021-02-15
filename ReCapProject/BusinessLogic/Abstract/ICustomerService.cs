using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(Expression<Func<Customer, bool>> filter);
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer Customer);
        IResult Update(Customer Customer);
        IResult Delete(Customer Customer);
    }
}
