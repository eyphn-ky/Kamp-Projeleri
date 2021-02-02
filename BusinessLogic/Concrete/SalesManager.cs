using GameSalesProject.BusinessLogic.Abstract;
using GameSalesProject.Entities.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.BusinessLogic.Concrete
{
    public class SalesManager : ISalesServices
    {
        private  decimal _UnitPrice;
        private Campaign _campaign;
        
        public SalesManager(Campaign campaign)
        {
            _campaign = campaign;
        }
        public void Sale(Game game,IPerson player)
        {
            _UnitPrice = game.UnitPrice;
            
            game.UnitPrice = game.UnitPrice * _campaign.Discount;
            Console.WriteLine(game.Name+"Adlı oyun " +player.Name+" adlı oyuncuya"+ game.UnitPrice +" fiyatıyla satıldı.");
            
            game.UnitPrice = _UnitPrice;
        }
    }
}
