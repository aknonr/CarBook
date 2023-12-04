using CarBook.Application.Features.CQRS.Commands.AboutCoomands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {

        private readonly IReporsitory<About> _reporsitory;

        public UpdateAboutCommandHandler(IReporsitory<About> reporsitory)
        {
            _reporsitory = reporsitory;
        }


        public async Task Handle(UpdateAboutCommand command)
        {
            var values = await _reporsitory.GetByIdAsync(command.AboutID);
            values.Title = command.Title;
            values.Description = command.Description;   
            values.ImageUrl = command.ImageUrl;
            await _reporsitory.UpdateAsync(values);
        }
    }
}
