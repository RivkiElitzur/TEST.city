using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TEST.city.Intefaces;

namespace TEST.city.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        protected readonly ICityService _service;
        public CityController(ILogger<CityController> logger, ICityService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet, Route("{name}")]
        public IEnumerable<string> GetCityList([FromRoute] string name)
        {
            return _service.GetCityList(name);
        }

        [HttpGet, Route("get-data/{name}")]
        public IEnumerable<City> GetDataByCity([FromRoute] string name)
        {
            return _service.GetDataByCity(name);
        }
    }
}
