using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface IBrandService
    {
        Brand GetById(Expression<Func<Brand, bool>> filter);
        List<Brand> GetAll();
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
