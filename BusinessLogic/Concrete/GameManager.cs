using GameSalesProject.BusinessLogic.Abstract;
using GameSalesProject.DataAccess.Abstract;
using GameSalesProject.DataAccess.Concrete;
using GameSalesProject.Entities.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.BusinessLogic.Concrete
{
    public class GameManager 
    {
      
        private IGameDal _gameDal;
        public GameManager(IGameDal gameDal)
        {
             _gameDal=gameDal;
        }
        public void Add(Game game)
        {
            _gameDal.Add(game);
        }

        public void Delete(Game game)
        {
            _gameDal.Delete(game);
        }

        public void Update(Game game)
        {
            _gameDal.Update(game);
        }
    }
}
