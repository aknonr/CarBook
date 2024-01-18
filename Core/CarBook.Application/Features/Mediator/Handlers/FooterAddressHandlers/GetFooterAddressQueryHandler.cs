
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery,
        List<GetFooterAddressQueryResult>>
    {
        private readonly IReporsitory<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IReporsitory<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            // GetFooterAddressQuery sorgusunu işleyen bir işleyici metodu içeriyor. Bu işleyici, bir veritabanından tüm ayak bilgilerini alır ve bu bilgileri GetFooterAddressQueryResult tipine dönüştürerek bir liste olarak döndürür.
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            //var values = await _repository.GetAllAsync();:
            //GetFooterAddressQuery sorgusunu işlemeye başlamadan önce, muhtemelen bir veritabanı bağlantısı üzerinden tüm ayak bilgilerini almak için _repository nesnesi kullanılır.GetAllAsync metodu, tüm ayak bilgilerini asenkron bir şekilde getirir.
            //Veritabanından alınan ayak bilgileri, LINQ Select operatörü kullanılarak GetFooterAddressQueryResult tipine dönüştürülür. Her bir öğe, GetFooterAddressQueryResult tipinde bir nesne oluşturulur ve içeriği veritabanından gelen x öğesinden alınır.
            {
                Adress = x.Adress,
                Description = x.Description,
                Email = x.Email,
                FooterAddressID = x.FooterAddressID,
                Phone= x.Phone,


            }).ToList();
            // Sonuç olarak Bu kod bloğu, bir sorgu işleyici metodu aracılığıyla bir veritabanından ayak bilgilerini çekmek ve bu bilgileri istemciye uygun bir formatta dönüştürerek liste olarak döndürmek için kullanılıyor...
        }
    }
}
