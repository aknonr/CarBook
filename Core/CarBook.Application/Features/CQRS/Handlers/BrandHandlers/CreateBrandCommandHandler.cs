using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {

        private readonly IReporsitory<Brand> _repository;   //Repository de olacak entity ...

        public CreateBrandCommandHandler(IReporsitory<Brand> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateBrandCommand command)
        {
            await _repository.CreateAsync(new Brand            
            {
                   Name=command.Name,
            });
        }

    }
}
