using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var customerJoin = from c in context.Customers
                                   join u in context.Users on c.UserId equals u.Id select new CustomerDetailDto
                                   {
                                       Id = c.Id,
                                       FirstName = u.FirstName,
                                       LastName = u.LastName
                                   };
                var result = from r in context.Rentals
                             join u in customerJoin
                             on r.CustomerId equals u.Id
                             join b in context.Brand on r.CarId equals b.Id
                             select new RentalDetailsDto
                             {
                               Id = r.Id,
                               BrandName = b.Name,
                               FirstName = u.FirstName,
                               LastName = u.LastName
                             };
                return result.ToList();
            }
        }
    }

}
