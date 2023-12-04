using CarBook.Application.İnterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class Repository<T> : IReporsitory<T> where T : class
    {
        private readonly CarBookContext _context ;   //Bağlantı aldığımız sınıftan  nesne örneklemesi yapıyoruz.

        public Repository(CarBookContext context)   //Yapıcı metot yaptık
        {
            _context = context;
        }

        public async Task CreateAsync(T entity) //Bu kod, genel bir CRUD (Create, Read, Update, Delete) işlemi içinde "Create" adımını temsil eder. Yani, veritabanına yeni bir varlık eklemek için kullanılır. Bu tür bir metot, genellikle bir repository veya service sınıfının bir parçası olarak kullanılır ve belirli bir varlık türünün veritabanı işlemlerini soyutlamak için tasarlanmış olabilir.
        {
           _context.Set<T>().Add(entity);
          await  _context.SaveChangesAsync();


        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
           _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
