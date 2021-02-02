using GameSalesProject.Entities.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.BusinessLogic.Abstract
{
    interface ISalesServices
    {
        public void Sale(Game game,IPerson player);
    }
}
