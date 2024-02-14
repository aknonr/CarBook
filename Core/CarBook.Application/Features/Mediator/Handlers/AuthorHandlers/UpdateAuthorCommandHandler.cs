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
    public class UpdateAuthorCommandHandler:IRequestHandler<UpdateAuthorCommand>

    {
        private readonly IReporsitory<Author> _repository;

        public UpdateAuthorCommandHandler(IReporsitory<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.AuthorID);
            values.Name = request.Name;
            values.Description = request.Description;
            values.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
