using CarBook.Application.Features.Mediator.Results.AuthorResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorQuery:IRequest<List<GetAuthorQueryResult>>

    // Sınıf Hakkında Açıklamalar : GetAuthorQuery sınıfı, tüm yazarların bilgilerini almak için kullanılan bir sorgu nesnesidir. Bu sorgu, tüm yazarların bilgilerini getirir. Çünkü genellikle bir veritabanındaki tüm kayıtları bir liste olarak döndürmek daha yaygın bir yaklaşımdır. Bu nedenle, bu sorgu bir liste olarak List<GetAuthorQueryResult> şeklinde sonuç döndürür.
    {
    }
}
