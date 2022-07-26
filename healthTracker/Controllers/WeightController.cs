using healthTracker.Data;
using healthTracker.Dtos;
using healthTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        private readonly ILogger<WeightController> _logger;
        private readonly IWeightRepo _weightRepo;
        
        public WeightController(ILogger<WeightController> logger, IWeightRepo weightRepo)
        {
            _logger = logger;   
            _weightRepo = weightRepo;
        }

        [HttpGet("Discovery")]
        public ActionResult Discovery()
        {
            string initialPath = "/api/Weight";
            var endpoints = new
            {
                GetById = new EndpointDiscovery
                {
                    Url = initialPath + "/{id}",
                    RequestType = "HttpGet",
                    Description = "Retrieves a weight with an integer Id."
                },
                Add = new EndpointDiscovery
                {
                    Url = initialPath,
                    RequestType = "HttpPost",
                    Description = "Adds a weight using a JSON format body."
                },
                Delete = new EndpointDiscovery
                {
                    Url = initialPath + "/{id}",
                    RequestType = "HttpDelete",
                    Description = "Deletes a weight with an integer Id."
                },
                Update = new EndpointDiscovery
                {
                    Url = initialPath + "/{id}",
                    RequestType = "HttpPut",
                    Description = "Updates a weight with an integer, using a JSON format body."
                }
            };

            var discovery = new
            {
                AvailableEndpoints = endpoints
            };

            return Ok(discovery);
        }

        [HttpGet("{id:int}")]
        public ActionResult<IBaseOutDto> GetById(int id)
        {
            Weight? weight = _weightRepo.GetById(id);
            if (weight == null)
                return NotFound();
            return Ok(weight.ConvertToDto());
        }
    }
}
