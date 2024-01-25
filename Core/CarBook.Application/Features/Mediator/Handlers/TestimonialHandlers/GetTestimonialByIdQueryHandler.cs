using CarBook.Application.Features.CQRS.Queries.AboutQueries;

using CarBook.Application.Features.Mediator.Queries.TestİmonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IReporsitory<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IReporsitory<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = values.TestimonialID,
                Name = values.Name,
                Comment = values.Comment,
                Title = values.Title, 
                ImageUrl=values.ImageUrl,
            };
        }
    }
}
