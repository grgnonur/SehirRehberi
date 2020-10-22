using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirRehberi.Model;

namespace SehirRehberi.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity); //ekleme işlemi Generic Method olarak
        void Delete<T>(T entity);//silme işlemi Generic olarak
        bool SaveAll(); //arka arkaya add yaptıktan sonra en son işlem olarak hepsini kaydetme işlemi

        //Veri Okuma işlemleri

        List<City> GetCities(); //Şehirleri listeleme işlemi Tüm şehirleri getirecek
        List<Photo> GetPhotosByCities(int cityId); //Bir şehrin fotoğraflarını çekiyor olcaz.
        City GetCityById(int cityId);//Tek bir şehrin detayına gitmek için şehrin datasını getirecek. Belli bir şehri getirecek
        Photo GetPhoto(int id);//Belli bir fotoğrafı getirecek.
    }
}
