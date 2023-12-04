using CarBook.Application.Features.CQRS.Commands.AboutCoomands;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IReporsitory<Banner> _repository;

        public CreateBannerCommandHandler(IReporsitory<Banner> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.CreateAsync(new Banner            //Burada About sınıfından örnek  aldık..
            {
               Description = command.Description,
               Title = command.Title,
               VideoDescription = command.VideoDescription,
               VideoUrl = command.VideoUrl,
            });
        }

    }
}
