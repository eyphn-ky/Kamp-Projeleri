using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.Entities.Abstract
{
     public interface IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
     }
}
