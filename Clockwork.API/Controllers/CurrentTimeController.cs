using Microsoft.AspNetCore.Mvc;
using System;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class TimeZonesController : Controller
    {
        [HttpPost]
        public IActionResult TimeZones()
        {
            return Ok(TimeZoneInfo.GetSystemTimeZones());
        }
    }
}
