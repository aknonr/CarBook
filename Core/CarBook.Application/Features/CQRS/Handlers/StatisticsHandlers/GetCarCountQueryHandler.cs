using CarBook.Application.Features.CQRS.Queries.StatisticsQueries;
using CarBook.Application.Features.CQRS.Results.StatisticsResult;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.İnterfaces;
using CarBook.Application.İnterfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly ICarRepository _repository;

        public GetCarCountQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetCarCount();
            return new GetCarCountQueryResult
            {
               CarCount = value,

            };
        }
    }
}
