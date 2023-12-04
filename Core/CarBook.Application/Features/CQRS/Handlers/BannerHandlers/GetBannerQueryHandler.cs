using CarBook.Application.Features.CQRS.Results.BannerResult;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IReporsitory<Banner> _reporsitory;

        public GetBannerQueryHandler(IReporsitory<Banner> reporsitory)
        {
            _reporsitory = reporsitory;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values= await _reporsitory.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerID = x.BannerID,
               Description = x.Description,
               Title = x.Title,
               VideoDescription = x.VideoDescription,
               VideoUrl = x.VideoUrl,
            }).ToList();
        }


    }
}
