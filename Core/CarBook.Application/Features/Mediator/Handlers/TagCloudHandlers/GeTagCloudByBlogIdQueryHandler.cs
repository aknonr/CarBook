using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResult;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GeTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GeTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {

            var values = _repository.GetTagCloudsByBlogID(request.Id);

            return values.Select(x=> new GetTagCloudByBlogIdQueryResult
            {
                BlogID = x.BlogID,
                TagCloudID = x.TagCloudID,
                Title=x.Title,
              
            }).ToList();

        }
    }
}
