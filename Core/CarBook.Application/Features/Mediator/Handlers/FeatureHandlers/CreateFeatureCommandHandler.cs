using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IReporsitory<Feature> _repository;

        public CreateFeatureCommandHandler(IReporsitory<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken) //CancellationToken nedir: Ödeme işlemi gerçekleştirecez mesela ödeme esnasında tarayıcıyı kapattığımızda bu işlem iptal olsun mu gibi görev üstleniyor. 
        {
            await _repository.CreateAsync(new Feature
            {
              Name = request.Name,
            });
        }
    }
}
