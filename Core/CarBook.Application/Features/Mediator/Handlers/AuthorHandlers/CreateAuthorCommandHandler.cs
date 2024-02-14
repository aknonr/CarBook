using CarBook.Application.Features.Mediator.Commands.AuthorCommand;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IReporsitory<Author> _repository;

        public CreateTestimonialCommandHandler(IReporsitory<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Author
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
              
            });
        }
    }
}
