using CarBook.Application.Features.Mediator.Queries.BlogQueries;

using CarBook.Application.Features.Mediator.Results.BlogResult;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IReporsitory<Blog> _repository;

        public GetBlogQueryHandler(IReporsitory<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogQueryResult
            {
              BlogID = x.BlogID,
              AuthorID = x.AuthorID,
              CategoryID = x.CategoryID,
              CoverImageUrl = x.CoverImageUrl,
              CreatedDate = x.CreatedDate,
              Title = x.Title

            }).ToList();
        }
    }
}
