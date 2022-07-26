using healthTracker.Data;
using healthTracker.Dtos;
using healthTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepo _userRepo;

        public UserController(ILogger<UserController> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        [HttpGet("Discovery")]
        public ActionResult Discovery()
        {
            string initialPath = "/api/User";
            var endpoints = new
            {
                GetById = new EndpointDiscovery { 
                    Url = initialPath + "/{id}", 
                    RequestType = "HttpGet", 
                    Description = "Retrieves a user with an integer Id."
                },
                Add = new EndpointDiscovery { 
                    Url = initialPath, 
                    RequestType = "HttpPost", 
                    Description = "Adds a user using a JSON format body." 
                },
                Delete = new EndpointDiscovery { 
                    Url = initialPath + "/{id}", 
                    RequestType = "HttpDelete", 
                    Description = "Deletes a user with an integer Id." 
                },
                Update = new EndpointDiscovery { 
                    Url = initialPath + "/{id}", 
                    RequestType = "HttpPut", 
                    Description = "Updates a user with an integer, using a JSON format body." 
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
            User? user = _userRepo.GetById(id);

            if (user != null)
                return Ok(user.ConvertToDto());

            return NotFound();
        }

        [HttpPost]
        public ActionResult<IBaseOutDto> Add(UserInDto userIn)
        {
            if (userIn == null || userIn.Email == null)
                return BadRequest();
            else if (_userRepo.EmailExists(userIn.Email))
                return BadRequest("Email already exists");

            User newUser = new()
            {
                FirstName = userIn.FirstName,
                LastName = userIn.LastName,
                Email = userIn.Email,
                Gender = userIn.Gender,
                Provider = userIn.Provider,
                Units = userIn.Units,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            bool success = _userRepo.Add(newUser);
            if (!success)
                return Problem();

            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser );
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            User? user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            bool success = _userRepo.Delete(user);
            if (!success)
                return Problem();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult<IBaseOutDto> Update(int id, UserInDto updatedUser)
        {
            User? user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();


            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Gender = updatedUser.Gender;
            user.Provider = updatedUser.Provider;
            user.Units = updatedUser.Units;
            user.DateUpdated = DateTime.Now;

            bool success = _userRepo.Update(user);
            if (!success)
                return Problem();

            return Ok(user.ConvertToDto());
        }
    }
}
