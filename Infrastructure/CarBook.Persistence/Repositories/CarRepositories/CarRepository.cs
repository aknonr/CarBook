using CarBook.Application.İnterfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {

        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarListWithBrands()
        {
            //GetCarListWithBrands: Bu metot, Cars tablosundaki tüm arabaları ve bu arabalara ait markaları içeren bir liste döndürür. Include metodu sayesinde, Cars tablosuyla birleştirilen Brand tablosundan gelen verileri içerir. Yani, bir araba nesnesi alırken aynı zamanda ilgili marka bilgilerini de alır.

            var values =_context.Cars.Include(x=>x.Brand).ToList();
            return values;
        }

        public List<Car> Getlast5CarsWithBrands()
        {
            //Getlast5CarsWithBrands: Bu metot, en son eklenen 5 arabayı ve bunlara ait markaları içeren bir liste döndürür. OrderByDescending ile arabalar CarID'ye göre azalan sırayla sıralanır ve Take(5) ile ilk 5 öğe alınır. Aynı şekilde, arabaların marka bilgilerini içerir.

            var values =_context.Cars.Include(x=>x.Brand).OrderByDescending(x=>x.CarID).Take(5).ToList();

            //.Include(x=>x.Brand): Cars tablosundaki her bir aracın bağlı olduğu Brand tablosunu içeri alır, yani bu sorguyla Car tablosundaki her bir aracın markasıyla birlikte çekilmesi sağlanır (Eager Loading).
            //Eager loading, bir ORM (Object-Relational Mapping) aracı kullanılarak veritabanından veri çekerken, ilgili nesneleri önceden yükleyip sorguya eklemektir. Bu, ilişkili nesnelerin (ilişkili tablolardaki verilerin) aynı anda çekilmesini sağlar ve bu sayede sorguların daha etkili ve optimize bir şekilde çalışmasına yardımcı olur.

           // Entity Framework gibi ORM araçları, varsayılan olarak ilişkili nesneleri yüklemeyebilir(lazy loading).Ancak, performans nedenleriyle bu nesnelerin anında yüklenmesi gereken durumlar olabilir.İşte bu durumu karşılamak için Eager loading kullanılır.

            return values;
        }
    }
}
