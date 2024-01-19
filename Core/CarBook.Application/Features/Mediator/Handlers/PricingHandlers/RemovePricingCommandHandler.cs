using CarBook.Application.Features.Mediator.Commands.PricingCommands;
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
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IReporsitory<Pricing> _repository;

        public RemovePricingCommandHandler(IReporsitory<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {

            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
