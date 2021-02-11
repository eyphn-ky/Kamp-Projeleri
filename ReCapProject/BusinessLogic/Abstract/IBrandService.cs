using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetById(Expression<Func<Brand, bool>> filter);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
