using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string BlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string BrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public int GetCarCount()
        {
            var value=_context.Cars.Count();
            return value;   
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public double GetAvgRentPriceForDaily()
        {
            throw new NotImplementedException();
        }

        public double GetAvgRentPriceForMonthly()
        {
            throw new NotImplementedException();
        }

        public double GetAvgRentPriceForWeekly()
        {
            throw new NotImplementedException();
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCountByFuelElectric()
        {
            throw new NotImplementedException();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            throw new NotImplementedException();
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            throw new NotImplementedException();
        }

        public int GetCarCountByTransmissionAuto()
        {
            throw new NotImplementedException();
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
