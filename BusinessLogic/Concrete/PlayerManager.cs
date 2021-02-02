using GameSalesProject.BusinessLogic.Abstract;
using GameSalesProject.BusinessLogic.Validation.Abstract;
using GameSalesProject.BusinessLogic.Validation.Concrete;
using GameSalesProject.DataAccess.Concrete;
using GameSalesProject.Entities.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.BusinessLogic.Concrete
{
    public class PlayerManager
    {
        private PlayerDal _playerDal;
        private IValidateService _validateService;


        public PlayerManager(IValidateService validateService)
        {
            validateService = _validateService;
          
        }

        public void Add(Player entity)
        {
            if(_validateService.Validate(entity))
            {
                Console.WriteLine("Doğrulama başarılı!");
                _playerDal.Add(entity);
            }
            else
            {
                Console.WriteLine("Doğrulama başarılı");
            }
           
        }

        public void Delete(Player entity)
        {
            Console.WriteLine("Oyuncu Silindi");
        }

        public void Update(Player entity)
        {
            Console.WriteLine("Oyuncu güncellendi");
        }
        public List<Player> GetAll()
        {
            return _playerDal.GetAll();
        }
    }
}
