using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();

        double GetAvgRentPriceForDaily();
        double GetAvgRentPriceForWeekly();
        double GetAvgRentPriceForMonthly();

        int GetCarCountByTransmissionAuto();

        string BrandNameByMaxCar();
        string BlogTitleByMaxBlogComment();
        int GetCarCountByKmSmallerThen1000();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMin();

    }
}
