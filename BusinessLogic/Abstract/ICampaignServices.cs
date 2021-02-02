using GameSalesProject.Entities.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.BusinessLogic.Abstract
{
    public interface ICampaignServices
    {
        public void Add(Campaign entity);
        public void Delete(Campaign entity);
        public void Update(Campaign entity);
    }
}
