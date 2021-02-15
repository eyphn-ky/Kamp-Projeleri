using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Concrete
{
    public class CustomerManager
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer Customer)
        {
            _customerDal.Add(Customer);
            return new SuccessResult();

        }

        public IResult Delete(Customer Customer)
        {
            _customerDal.Delete(Customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>();
        }

        public IDataResult<Customer> GetById(Expression<Func<Customer, bool>> filter)
        {
            _customerDal.GetById(filter);
            return new SuccessDataResult<Customer>();
        }

        public IResult Update(Customer Customer)
        {
            _customerDal.Update(Customer);
            return new SuccessResult();
        }
    }
}
