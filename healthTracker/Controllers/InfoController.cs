using healthTracker.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace healthTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly HealthTrackerOptions _info;
        public InfoController(IOptions<HealthTrackerOptions> info)
        {
            _info = info.Value;
        }

        [HttpGet("version")]
        [Produces("application/json")]
        public IActionResult GetVersion()
        {
            var result = new
            {
                Result = _info.Version
            };
            return Ok(result);
        }

        [HttpGet("Github")]
        [Produces("application/json")]
        public IActionResult GetGithub()
        {
            var result = new
            {
                Result = _info.Github
            };
            return Ok(result);
        }

        [HttpGet("WebApp")]
        [Produces("application/json")]
        public IActionResult GetFrontEndWebApp()
        {
            if (string.IsNullOrEmpty(_info.FrontEndWebApp))
                return NotFound(new { Error = "Frontend Web App has not yet been released." });
            var result = new
            {
                Result = _info.FrontEndWebApp
            };
            return Ok(result);
        }
    }
}
