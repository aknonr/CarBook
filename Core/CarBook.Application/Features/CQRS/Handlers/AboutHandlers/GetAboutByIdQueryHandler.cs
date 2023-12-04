using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {

        private readonly IReporsitory<About> _reporsitory;

        public GetAboutByIdQueryHandler(IReporsitory<About> reporsitory)
        {
            _reporsitory = reporsitory;
        }


        public async  Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query) 
        {
            About values =await _reporsitory.GetByIdAsync(query.Id);

            return new GetAboutByIdQueryResult
            {
                AboutID = values.AboutID,
                Description = values.Description,
                ImageUrl = values.ImageUrl,
                Title = values.Title,
            };

        }
    }
}
