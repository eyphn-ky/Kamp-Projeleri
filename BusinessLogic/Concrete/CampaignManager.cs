using GameSalesProject.BusinessLogic.Abstract;
using GameSalesProject.DataAccess.Abstract;
using GameSalesProject.Entities.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.BusinessLogic.Concrete
{
    public class CampaignManager : ICampaignServices
    {
        private ICampaignDal _campaignDal;
        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
        }
        public void Add(Campaign campaign)
        {
            _campaignDal.Add(campaign);
           
        }

        public void Delete(Campaign campaign)
        {
            _campaignDal.Delete(campaign);
        }

        public void Update(Campaign campaign)
        {
            _campaignDal.Update(campaign);
        }
    }
}
