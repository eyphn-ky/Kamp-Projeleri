using GameSalesProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.DataAccess.Abstract
{
    public interface IRepositoryBase<T> where T:class,new()
    {
        List<T> GetAll();
        T Get(int filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
