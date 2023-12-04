using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {

        private readonly IReporsitory<About> _reporsitory;

        public GetAboutQueryHandler(IReporsitory<About> reporsitory)
        {
            _reporsitory = reporsitory;
        }


        public async Task<List<GetAboutByIdQueryResult>> Handle()
        {
            //Bu metodun amacı, veritabanındaki tüm "About" varlıklarını belirli bir türdeki nesnelere dönüştürerek bu nesnelerin bulunduğu bir listeyi döndürmektir. Bu tür bir işlev genellikle bir uygulamanın arayüz katmanında veya bir servis sınıfında kullanılabilir.
            var values = await  _reporsitory.GetAllAsync();

            return values.Select(x => new GetAboutByIdQueryResult  //return values.Select(x => new GetAboutByIdQueryResult { /* ... */ }).ToList();: Bu satır, values adlı varlık listesini kullanarak her bir varlığı GetAboutByIdQueryResult türündeki bir nesneye dönüştürüp, bu nesnelerin bulunduğu bir liste olarak döndürür
            {
            
            AboutID = x.AboutID,//AboutID = x.AboutID: Her bir GetAboutByIdQueryResult nesnesinin AboutID özelliği, orijinal About varlığının AboutID özelliği ile eşleştirilir.
                Description = x.Description,//Description = x.Description: Her bir GetAboutByIdQueryResult nesnesinin Description özelliği, orijinal About varlığının Description özelliği ile eşleştiril
                Title = x.Title, //Title = x.Title: Her bir GetAboutByIdQueryResult nesnesinin Title özelliği, orijinal About varlığının Title özelliği ile eşleştirilir.
                ImageUrl = x.ImageUrl,
            
            }).ToList();

            
            
        }
    }
}
