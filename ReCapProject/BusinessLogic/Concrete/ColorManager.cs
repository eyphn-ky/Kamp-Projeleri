using BusinessLogic.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BusinessLogic.Constants;

namespace BusinessLogic.Concrete
{
    public class ColorManager : IColorService
    {
        private  IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            //İŞ KURALLARI

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            //İŞ KURALLARI

            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
        
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(Expression<Func<Color, bool>> filter)
        {
            return new SuccessDataResult<Color>(_colorDal.GetById(filter));
        }

        public IResult Update(Color color)
        {
            //İŞ KURALLARI
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
