using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler:IRequestHandler<UpdateSocialMediaCommand>

    {
        private readonly IReporsitory<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IReporsitory<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.SocialMediaID);
            values.Name = request.Name;
           values.SocialMediaID = request.SocialMediaID;
            values.Url = request.Url;
            values.Icon = request.Icon;
            await _repository.UpdateAsync(values);
        }
    }
}
