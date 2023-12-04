using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IReporsitory<Category> _repository;

        public RemoveCategoryCommandHandler(IReporsitory<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)  //Silme metodu yaptık..
        {

            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
