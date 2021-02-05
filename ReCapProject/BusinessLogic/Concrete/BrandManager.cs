using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public void Add(Brand brand)
        {
           
            if(brand.Name.Length>=2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Kayıt Başarılı!!");
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır!!");
            }
        }

        public void Delete(Brand brand)
        {
            //İŞ KURALLARI
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            return _brandDal.GetById(filter);
        }

        public void Update(Brand brand)
        {
            if (brand.Name.Length >= 2)
            {
                _brandDal.Update(brand);
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır!!");
            }

        }
    }
}
