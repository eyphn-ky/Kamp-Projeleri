using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<RentCarContext, Rental>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             select new RentalDetailsDto
                             {
                                 CarId=c.Id,
                                 Id = r.Id,
                                 CompanyName=
                             }


            }
        }
    }
}
