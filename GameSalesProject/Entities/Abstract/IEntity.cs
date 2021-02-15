using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.Entities.Abstract
{
     public interface IEntity
    {
         int Id { get; set; }
         string Name { get; set; }
        
     }
}
