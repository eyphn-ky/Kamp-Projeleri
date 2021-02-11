using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
     public interface IColorService
    {
        IDataResult<Color> GetById (Expression<Func<Color, bool>> filter);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);

    }
}
