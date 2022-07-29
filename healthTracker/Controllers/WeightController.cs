using healthTracker.Data;
using healthTracker.Dtos;
using healthTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthTracker.Controllers
{
    [Route("api/")]
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

        [HttpGet("[controller]/Discovery")]
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

        [HttpGet("[controller]/{id:int}")]
        public ActionResult<IBaseOutDto> GetById(int id)
        {
            Weight? weight = _weightRepo.GetById(id);
            if (weight == null)
                return NotFound();
            return Ok(weight.ConvertToDto());
        }

        [HttpPost("[controller]")]
        public ActionResult<IBaseOutDto> Add(WeightInDto weightIn)
        {
            User? user = _weightRepo.GetUserById(weightIn.UserId);
            if (user == null)
                return BadRequest("User not found!");

            Weight newWeight = new()
            {
                UserId = weightIn.UserId,
                Poundage = weightIn.Poundage,
                Date = weightIn.Date,
                Units = weightIn.Units,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            bool success = _weightRepo.Add(newWeight);
            if (!success)
                return Problem();
            return CreatedAtAction(nameof(GetById), new { id = newWeight.Id }, newWeight);
        }

        [HttpDelete("[controller]/{id:int}")]
        public ActionResult Delete(int id)
        {
            Weight? weight = _weightRepo.GetById(id);
            if (weight == null)
                return NotFound();

            bool success = _weightRepo.Delete(weight);
            if (!success)
                return Problem();
            return NoContent();
        }

        [HttpPut("[controller]/{id:int}")]
        public ActionResult<IBaseOutDto> Update(int id, WeightInDto updatedWeight)
        {
            Weight? weight = _weightRepo.GetById(id);
            if (weight == null)
                return NotFound();

            weight.Poundage = updatedWeight.Poundage;
            weight.Date = updatedWeight.Date;
            weight.Units = updatedWeight.Units;
            weight.DateUpdated = DateTime.Now;

            bool success = _weightRepo.Update(weight);
            if (!success)
                return Problem();

            return Ok(weight.ConvertToDto());
        }

        [Authorize]
        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [Route("User/{id:int}/Weights")]
        [HttpGet]
        public ActionResult GetWeightsByUserId(int id)
        {
            User? user = _weightRepo.GetUserById(id);
            if (user == null || user.Email != User.Claims.ToList()[0].Value)
                return NotFound("Invalid user");
            
            IEnumerable<Weight> weights = _weightRepo.GetByUserId(id);
            int total = weights.Count();

            // int limit is defined here
            if (String.IsNullOrEmpty(Request.Query["limit"].ToString().Trim()) || !int.TryParse(Request.Query["limit"].ToString().Trim(), out int limit))
                limit = _weightRepo.DefaultLimit;
            // int offset is defined here
            if (String.IsNullOrEmpty(Request.Query["offset"].ToString().Trim()) || !int.TryParse(Request.Query["offset"].ToString().Trim(), out int offset))
                offset = _weightRepo.DefaultOffset;


            List<WeightOutDto> weightOutDtos = new();

            // Skip & Limit are LINQ equivalent of Offset & Limit
            foreach (Weight weight in weights.Skip(offset).Take(limit))
                weightOutDtos.Add((WeightOutDto)weight.ConvertToDto());

            var collection = new
            {
                Values = weightOutDtos,
                Total = total,
                Limit = limit,
                Offset = offset
            };

            return Ok(collection);
        }
    }
}
