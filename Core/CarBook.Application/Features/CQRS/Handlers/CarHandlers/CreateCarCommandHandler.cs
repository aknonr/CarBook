using CarBook.Application.Features.CQRS.Commands.BrandCommand;

using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IReporsitory<Car> _repository;   //Repository de olacak entity ...

        public CreateCarCommandHandler(IReporsitory<Car> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {

                BigImageUrl = command.BigImageUrl,
                Km=command.Km,  
                Model=command.Model,
                Seat = command.Seat,
                Transmission=command.Transmission,
                CoverImageUrl=command.CoverImageUrl,
                BranID=command.BranID,
                 Fuel=command.Fuel,

            });
        }
    }
}
