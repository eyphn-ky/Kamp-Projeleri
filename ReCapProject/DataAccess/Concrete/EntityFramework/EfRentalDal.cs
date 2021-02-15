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
        public RentalDetailsDto GetRentalDetails(int Id)
        {

            using (RentCarContext context = new RentCarContext())
            {
               
                var result = (from c in context.Cars
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.Id equals u.Id

                             where r.CarId == Id
                             orderby r.Id ascending

                             select new RentalDetailsDto
                             {
                                 CarId = c.Id,
                                 Id = r.Id,
                                 CompanyName = cu.CompanyName,
                                 CustomerId = cu.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 ModelYear = c.ModelYear,
                                 Name = c.Name,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             }).LastOrDefault();


                return result;


            }
        }
    }
}
