using Core.Entities.Concrete;
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
        IResult Add(User User);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string mail);
    }
}
