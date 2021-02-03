using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    public interface IVehicle
    {
        int Id { get; set; }
        int BrandId { get; set; }
        int ColorId { get; set; }
        string ModelYear { get; set; }
        decimal DailyPrice { get; set; }
        string Description { get; set; }

    }
}
