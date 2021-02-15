using GameSalesProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.Entities.Concrete
{
    public class Game : IEntity
    {
        public int Id { get ; set; }
        public string Name { get ; set ; }
        public string ReleaseDate { get; set; }
        public string Type { get; set; }
        public string Publisher { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
