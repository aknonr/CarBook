using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommand
{
    public class CreateBrandCommand
    {
        public string Name { get; set; } //Ekleme işleminde sadece adı yeterli olacaktır


    }
}
