using CarBook.Application.Features.CQRS.Results.StatisticsResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.StatisticsQueries
{
    public class GetCarCountQuery:IRequest<GetCarCountQueryResult>
    {

    }
}
