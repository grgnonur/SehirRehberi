using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.Data;

namespace SehirRehberi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        //Get api/values
        [HttpGet]
        public ActionResult GetValues()
        {
            var value = _context.Test.ToList();
            return Ok(value);
        }
        //Get api/values/5
        [HttpGet("{id}")]
        public ActionResult GetValus(int id)
        {
            var values = _context.Test.FirstOrDefault(v => v.Id == id);
            return Ok(values);
        }
    }
}
