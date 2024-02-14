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
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IReporsitory<Author> _repository;

        public RemoveAuthorCommandHandler(IReporsitory<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {

            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
