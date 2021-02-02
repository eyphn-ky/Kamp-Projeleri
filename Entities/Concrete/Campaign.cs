using GameSalesProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.Entities.Concrete
{
    public class Campaign : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Discount { get; set; }
    }
}
