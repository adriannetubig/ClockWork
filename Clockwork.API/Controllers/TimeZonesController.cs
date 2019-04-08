using Microsoft.AspNetCore.Mvc;
using Clockwork.Business.Interfaces;
using Clockwork.Data.Services;
using Clockwork.Business.Services;
using Clockwork.Data.Interfaces;
using AutoMapper;
using System;

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

        [HttpGet("{offSet?}")]
        public IActionResult Read(string offSet)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return Ok(_iBusinessServiceCurrentTimeQuery.Read(ipAddress, offSet));
        }

        [HttpPost("Queries")]
        public IActionResult Queries()
        {
            return Ok(_iBusinessServiceCurrentTimeQuery.Read());
        }

        [HttpPost("TimeZones")]
        public IActionResult TimeZones()
        {
            return Ok(TimeZoneInfo.GetSystemTimeZones());
        }
    }
}
