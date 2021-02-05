using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace BusinessLogic.Concrete
{
    public class ColorManager : IColorService
    {
        private  IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            //İŞ KURALLARI
            _colorDal.Add(color);

        }

        public void Delete(Color color)
        {
            //İŞ KURALLARI
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
           return  _colorDal.GetAll();
        }

        public Color GetById(Expression<Func<Color, bool>> filter)
        {
            return _colorDal.GetById(filter);
        }

        public void Update(Color color)
        {
            //İŞ KURALLARI
            _colorDal.Update(color);
        }
    }
}
