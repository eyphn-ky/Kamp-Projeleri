using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(Expression<Func<User, bool>> filter);
        IDataResult<List<User>> GetAll();
        IResult Add(User User);
        IResult Update(User User);
        IResult Delete(User User);
    }
}
