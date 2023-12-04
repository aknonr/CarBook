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
    public class RemoveBannerCommandHandler
    {
        private readonly IReporsitory<Banner> _repository;

        public RemoveBannerCommandHandler(IReporsitory<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand command)  //Silme metodu yaptık..
        {

            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
