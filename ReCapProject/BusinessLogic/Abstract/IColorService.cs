using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Abstract
{
     public interface IColorService
    {
        Color GetById(Expression<Func<Color, bool>> filter);
        List<Color> GetAll();
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);

    }
}
