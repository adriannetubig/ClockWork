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
        public CurrentTimeController()
        {
            IDataServiceCurrentTimeQuery iDataServiceCurrentTimeQuery = new DataServiceCurrentTimeQuery();

            var mapperConfiguration = new MapperConfiguration(cfg => { });
            IMapper mapper = new Mapper(mapperConfiguration);

            var businessServiceCurrentTimeQuery = new BusinessServiceCurrentTimeQuery(iDataServiceCurrentTimeQuery, mapper);

            _iBusinessServiceCurrentTimeQuery = businessServiceCurrentTimeQuery;
        }

        [HttpGet]
        public IActionResult Read()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            return Ok(_iBusinessServiceCurrentTimeQuery.Read(ipAddress));
        }

        [HttpPost("Queries")]
        public IActionResult Queries()
        {
            return Ok(_iBusinessServiceCurrentTimeQuery.Read());
        }
    }
}
