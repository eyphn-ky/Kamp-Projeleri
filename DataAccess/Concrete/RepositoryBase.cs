using GameSalesProject.DataAccess.Abstract;
using GameSalesProject.Entities.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace GameSalesProject.DataAccess.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T:class ,IEntity,new()
        {
        List<T> _entities = new List<T>();
        public void Add(T entity)
        {
            _entities.Add(entity);
            Console.WriteLine(entity.Name+" isimli varlık eklendi");
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            Console.WriteLine("{0} Id'li varlık silindi!", entity.Id);
        }

        public T Get(int filter)
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                if (_entities[i].Id == filter)
                {
                    return _entities[i];
                }
            }
           throw new Exception("Kayıt bulunamadı");
        }

        public List<T> GetAll()
        {
            return _entities;
        }

        public void Update(T entity)
        {
         
            Console.WriteLine("{0} Adlı varlık güncellendi ", entity.Name);
        }
    }
}
