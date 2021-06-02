using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join br in context.Brand
                             on c.BrandId equals br.Id
                             join co in context.Color on c.ColorId equals co.Id
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = br.Name,
                                 Description = c.Description,
                                 ColorName = co.Name
                             };
                return result.ToList();
            }
        }
    }
}
