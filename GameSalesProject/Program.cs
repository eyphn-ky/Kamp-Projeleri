using GameSalesProject.BusinessLogic.Abstract;
using GameSalesProject.BusinessLogic.Concrete;
using GameSalesProject.BusinessLogic.Validation.Abstract;
using GameSalesProject.BusinessLogic.Validation.Concrete;
using GameSalesProject.DataAccess.Abstract;
using GameSalesProject.DataAccess.Concrete;
using GameSalesProject.Entities.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace GameSalesProject
{
    class Program
    {
        static void Main(string[] args)
        {

            IPerson player = new Player
            {
                Id = 34,
                Name = "Eyüphan",
                LastName = "KAYA",
                Country = "Türkiye",
                NickName = "eyphn.ky",
                DateOfBirth = "1999",
                NationalIdentity = "11111111111"
            };
            
            IPerson player1 = new Player
            {
                Id = 78,
                Name = "Yunus",
                LastName = "MERT",
                Country = "Türkiye",
                NickName = "yns.mrt",
                DateOfBirth ="2000",
                NationalIdentity="11111111111"
            };
            IValidateService validateService = new MernisValidateService();
            Campaign campaign = new Campaign
            {
                Discount = 0.75m,
                Id = 1,
                Name = "Summer Campaign"
            };
            PlayerManager playerManager = new PlayerManager(validateService) ;


            Game Valorant = new Game
            {
                Id = 20,
                Name = "Valorant",
                Publisher = "Riot Games",
                ReleaseDate = "02/06/2020",
                Type = "First Person Shooter",
                UnitPrice = 200m
            };
            IGameDal gameDal = new GameDal();
            GameManager gameManager = new GameManager(gameDal);
            
            gameManager.Add(Valorant);
            gameManager.Update(Valorant);
            gameManager.Delete(Valorant);

            
            ISalesServices salesManager= new SalesManager(campaign);
            salesManager.Sale(Valorant,player1);
            Console.WriteLine(Valorant.UnitPrice); 

            Console.ReadLine();



        }
    }
}
