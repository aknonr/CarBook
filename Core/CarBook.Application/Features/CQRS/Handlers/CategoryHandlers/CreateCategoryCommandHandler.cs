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
    public class CreateCategoryCommandHandler
    {
        private readonly IReporsitory<Category> _repository;   //Repository de olacak entity ...

        public CreateCategoryCommandHandler(IReporsitory<Category> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new Category
            {
                Name = command.Name,
            });
        }
    }
}
