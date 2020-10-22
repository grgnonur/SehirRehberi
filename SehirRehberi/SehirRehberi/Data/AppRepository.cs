using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.Model;

namespace SehirRehberi.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context; //Injection işlemi
        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity)
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public List<City> GetCities()
        {
            var city = _context.Cities.Include(c => c.Photos).ToList(); //City içinde ilişkili olarak photoslarda var city getiriken onlarıda getiriyoruz. Include(c=>c.Photos)Bunu sağlıyor.
            return city;
        }

        public City GetCityById(int cityId)
        {
            var city = _context.Cities.Include(c => c.Photos).FirstOrDefault(c => c.Id == cityId);
            return city;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            return photo;
        }

        public List<Photo> GetPhotosByCities(int cityId)
        {
            var photos = _context.Photos.Where(p => p.CityId == cityId).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0; // Gercekten eklenen güncellenen bir kayıt var ise
        }
    }
}
