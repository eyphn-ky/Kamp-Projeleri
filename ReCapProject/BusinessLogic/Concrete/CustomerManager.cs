using BusinessLogic.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Concrete
{
    public class CustomerManager : ICustomerService
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
        public IResult Update(Customer Customer)
        {
            _customerDal.Update(Customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer Customer)
        {
            _customerDal.Delete(Customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
           
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(Expression<Func<Customer, bool>> filter)
        {
            
            return new SuccessDataResult<Customer>(_customerDal.GetById(filter));
        }

     
    }
}
