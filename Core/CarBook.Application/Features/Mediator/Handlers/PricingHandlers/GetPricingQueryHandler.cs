using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.LocationResult;
using CarBook.Application.Features.Mediator.Results.PricingResult;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IReporsitory<Pricing> _repository;

        public GetPricingQueryHandler(IReporsitory<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult
            {
                Name = x.Name,
               PricingID = x.PricingID,
            }).ToList();
        }
    }
}
