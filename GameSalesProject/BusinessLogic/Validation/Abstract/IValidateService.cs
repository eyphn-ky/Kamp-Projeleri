using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.BusinessLogic.Validation.Abstract
{
    public interface IValidateService
    {
        bool Validate(Player player);
    }
}
