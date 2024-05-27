using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class // Dışarıdan bir T değeri alacak ve bu değer mutlaka Class olmak zorunda . 
    {

        List<T> GetAll(); //Burada List bize burda bütün T değerlerini döndürecek..

        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);

        T GetById(int id);
        List<T> GetCommandsByBlogId(int id);


    }
}
