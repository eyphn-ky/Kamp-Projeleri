using GameSalesProject.BusinessLogic.Validation.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.BusinessLogic.Validation.Concrete
{
   public class MernisValidateService : IValidateService
    {
       public bool Validate(Player player)
        {
            if (player.Id != 0 && player.Name.Length > 1 && player.LastName.Length > 1 && player.DateOfBirth.Length >= 4 && player.NationalIdentity.Length == 11)
            {
                return true;
            }
            return false;

        }

      
    }
}
