﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.İnterfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarListWithBrands();
        List<Car> Getlast5CarsWithBrands();

        int GetCarCount();
  
    }
}
