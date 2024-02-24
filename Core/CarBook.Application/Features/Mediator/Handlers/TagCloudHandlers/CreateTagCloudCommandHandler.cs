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
    public class CreateTagCloudCommandHandler:IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IReporsitory<TagCloud> _repository;

        public CreateTagCloudCommandHandler(IReporsitory<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TagCloud
            {
                Title = request.Title,
                BlogID = request.BlogID,

            });
        }
    }
}
