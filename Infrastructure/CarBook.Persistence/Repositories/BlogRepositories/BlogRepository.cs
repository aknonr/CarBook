using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        // Yukarıdaki Yapılan Const, "bağımlılık enjeksiyonu" prensibine uygun olarak, sınıfın bu bağımlılığı dışarıdan almasını sağlamaktır. Bu sayede, BlogRepository sınıfı, CarBookContext nesnesine doğrudan erişim sağlamaz; bunun yerine bu bağımlılık, sınıfın dışından enjekte edilir.

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            var values = _carBookContext.Blogs.Include(x=>x.Author).OrderByDescending(x=>x.BlogID).Take(3) .ToList();
        //OrderByDescending: Verileri belirtilen bir özelliğe göre azalan sırada sıralar.
        //Take: Belirtilen sayıda öğe alır.
        // ToList: Sorgunun sonucunu bir liste olarak döndürür.

            return values;
        }
    }
}
