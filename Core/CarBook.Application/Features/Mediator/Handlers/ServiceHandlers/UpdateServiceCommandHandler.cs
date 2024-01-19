using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler:IRequestHandler<UpdateServiceCommand>

    {
        private readonly IReporsitory<Service> _repository;

        public UpdateServiceCommandHandler(IReporsitory<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.ServiceID);
            values.Title = request.Title;
            values.Description = request.Description; 
            values.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
