
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
    public class UpdateContactCommandHandler
    {
        private readonly IReporsitory<Contact> _repository;

        public UpdateContactCommandHandler(IReporsitory<Contact> repository)
        {
            _repository = repository;
        }



        public async Task Handle(UpdateContactCommand command)
        {
            var values = await _repository.GetByIdAsync(command.ContactID);
            values.Name = command.Name;
            values.Email = command.Email;
            values.Message = command.Message;
            values.Subject = command.Subject;
            values.SendDate = command.SendDate;
            await _repository.UpdateAsync(values);
        }
    }
}
