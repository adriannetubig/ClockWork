using Microsoft.AspNetCore.Mvc;
using Clockwork.Business.Interfaces;
using Clockwork.Data.Services;
using Clockwork.Business.Services;
using Clockwork.Data.Interfaces;
using AutoMapper;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeController : Controller
    {
        private readonly IBusinessServiceCurrentTimeQuery _iBusinessServiceCurrentTimeQuery;
        public CurrentTimeController ()
        {
            IDataServiceCurrentTimeQuery iDataServiceCurrentTimeQuery = new DataServiceCurrentTimeQuery();

            var mapperConfiguration = new MapperConfiguration(cfg => { });
            IMapper mapper = new Mapper(mapperConfiguration);

            var businessServiceCurrentTimeQuery = new BusinessServiceCurrentTimeQuery(iDataServiceCurrentTimeQuery, mapper);

            _iBusinessServiceCurrentTimeQuery = businessServiceCurrentTimeQuery;
        }
        // GET api/currenttime
        [HttpGet]
        public IActionResult Get()
        {
            var ipAddress = this.HttpContext.Connection.RemoteIpAddress.ToString();

            return Ok(_iBusinessServiceCurrentTimeQuery.Create(ipAddress));
        }

        // Post api/currenttime
        [HttpPost]
        public IActionResult Post()
        {
            return Ok(_iBusinessServiceCurrentTimeQuery.Read());
        }
    }
}
