using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>

    {
        private readonly IReporsitory<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IReporsitory<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.TagCloudID);
          values.Title = request.Title;
            values.BlogID = request.BlogID;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}
