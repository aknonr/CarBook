
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IReporsitory<Contact> _repository;

        public RemoveContactCommandHandler(IReporsitory<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)  //Silme metodu yaptık..
        {

            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
