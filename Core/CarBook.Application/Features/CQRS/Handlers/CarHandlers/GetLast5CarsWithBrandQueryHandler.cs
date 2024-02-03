using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.İnterfaces;
using CarBook.Application.İnterfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

    

        public  List<GetCarWithBrandQueryResult> Handle()
        {

            //Burada diğer GetCarQueryHandler sınıfında farkı include metoduna ihtiyacımız olacak
            var values =  _repository.Getlast5CarsWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName=x.Brand.Name,
                BrandID = x.BrandID,
                BigImageUrl = x.BigImageUrl,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission,




            }).ToList();
        }

    }
}
