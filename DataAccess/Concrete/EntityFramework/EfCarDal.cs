﻿using Core.DataAccess.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join clr in context.Color
                             on c.ColorId equals clr.ColorId
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = clr.ColorName, DailyPrice = c.DailyPrice };
          
                return result.ToList(); 
            }
            
        }
    }

}       
    
