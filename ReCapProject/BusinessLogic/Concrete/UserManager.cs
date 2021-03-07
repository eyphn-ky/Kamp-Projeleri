using BusinessLogic.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal UserDal)
        {
            _userDal = UserDal;
        }

        public IResult Add(User User)
        {
            _userDal.Add(User);
            return new SuccessResult();

        }

        public IDataResult<User> GetByMail(string mail)
        {
            return new SuccessDataResult<User>(_userDal.GetById(p => p.Email == mail));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
