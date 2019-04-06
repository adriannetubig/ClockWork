using Microsoft.AspNetCore.Mvc;
using Clockwork.Business.Interfaces;
using Clockwork.Data.Services;
using Clockwork.Business.Services;
using Clockwork.Data.Interfaces;
using AutoMapper;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrrentTimeController : Controller
    {
        private readonly IBusinessServiceCurrentTimeQuery _iBusinessServiceCurrentTimeQuery;
        public CurrrentTimeController()
        {
            IDataServiceCurrentTimeQuery iDataServiceCurrentTimeQuery = new DataServiceCurrentTimeQuery();

            var mapperConfiguration = new MapperConfiguration(cfg => { });
            IMapper mapper = new Mapper(mapperConfiguration);

            var businessServiceCurrentTimeQuery = new BusinessServiceCurrentTimeQuery(iDataServiceCurrentTimeQuery, mapper);

            _iBusinessServiceCurrentTimeQuery = businessServiceCurrentTimeQuery;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            return Ok(_iBusinessServiceCurrentTimeQuery.Create(ipAddress));
        }

        [HttpPost("Queries")]
        public IActionResult Post()
        {
            return Ok(_iBusinessServiceCurrentTimeQuery.Read());
        }
    }
}
