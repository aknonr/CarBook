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
    public class RemoveCarCommandHandler
    {
        private readonly IReporsitory<Car> _repository;

        public RemoveCarCommandHandler(IReporsitory<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarCommand command)  //Silme metodu yaptık..
        {

            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }


    }
}
