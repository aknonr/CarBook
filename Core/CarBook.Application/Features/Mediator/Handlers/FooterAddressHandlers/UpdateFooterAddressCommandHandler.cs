using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IReporsitory<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IReporsitory<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FooterAddressID);
            values.Phone = request.Phone;
            values.Adress = request.Adress;
            values.Email = request.Email;
            values.Description = request.Description;

            await _repository.UpdateAsync(values);
        }
    }
}
