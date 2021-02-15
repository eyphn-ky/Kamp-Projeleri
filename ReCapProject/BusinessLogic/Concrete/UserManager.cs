﻿using BusinessLogic.Abstract;
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

        public IResult Delete(User User)
        {
            _userDal.Delete(User);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            _userDal.GetAll();
            return new SuccessDataResult<List<User>>();
        }

        public IDataResult<User> GetById(Expression<Func<User, bool>> filter)
        {
            _userDal.GetById(filter);
            return new SuccessDataResult<User>();
        }

        public IResult Update(User User)
        {
            _userDal.Update(User);
            return new SuccessResult();
        }
    }
}