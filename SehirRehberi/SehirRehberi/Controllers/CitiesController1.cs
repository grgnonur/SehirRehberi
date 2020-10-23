using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.Data;
using SehirRehberi.DTO;
using SehirRehberi.Model;

namespace SehirRehberi.Controllers
{
    [Route("api/Cities")]
    [ApiController]
    public class CitiesController1 : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
        public CitiesController1(IAppRepository appRepository,IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        public ActionResult GetCities()
        {
            // var cities = _appRepository.GetCities().Select(x => new CityForListDto() { Description = x.Description, Name=x.Name, PhotoUrl=x.Photos.FirstOrDefault(p=>p.IsMain==true).Url });
            var cities = _appRepository.GetCities();
            var citiesToReturn =    _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);
        }
        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }
        [HttpGet]
        [Route("detail")]
        public ActionResult GetCityById(int id)
        {
            var city = _appRepository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetail>(city);
            return Ok(cityToReturn);
        }
        [HttpGet]
        [Route("photos")]
        public ActionResult GetPhotosByCity(int cityId)
        {
            var photos = _appRepository.GetPhotosByCities(cityId);
            return Ok(photos);
        }


    }
}
