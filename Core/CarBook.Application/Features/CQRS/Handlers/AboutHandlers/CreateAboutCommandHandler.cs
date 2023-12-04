using CarBook.Application.Features.CQRS.Commands.AboutCoomands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IReporsitory<About> _repository;

        public CreateAboutCommandHandler(IReporsitory<About> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateAboutCommand command) 
        {
            await _repository.CreateAsync(new About            //Burada About sınıfından örnek  aldık..
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl,

            });
        }



    }
}
