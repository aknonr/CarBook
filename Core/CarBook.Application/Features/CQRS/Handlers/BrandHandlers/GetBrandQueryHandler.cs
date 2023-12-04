using CarBook.Application.Features.CQRS.Results.BannerResult;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {

        private readonly IReporsitory<Brand> _repository;

        public GetBrandQueryHandler(IReporsitory<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBrandQueryResult
            {
                
                BrandID = x.BrandID,
                  Name=x.Name,
             
            }).ToList();
        }

    }
}
