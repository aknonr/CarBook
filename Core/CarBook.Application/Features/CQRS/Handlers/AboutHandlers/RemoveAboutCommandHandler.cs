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
    public class RemoveAboutCommandHandler
    {
        private readonly IReporsitory<About> _reporsitory;


        public RemoveAboutCommandHandler(IReporsitory<About> reporsitory)
        {
            _reporsitory = reporsitory;
            
        }


        public async Task Handle(RemoveAboutCommand command)  //Silme metodu yaptık..
        {

            var value = await _reporsitory.GetByIdAsync(command.Id);
            await _reporsitory.RemoveAsync(value);
        }


    }
}
