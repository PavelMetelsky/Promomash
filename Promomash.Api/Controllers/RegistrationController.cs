using MediatR;
using Microsoft.AspNetCore.Mvc;
using Promomash.Core.Commands.CreateUser;
using Promomash.Core.Queries.GetUsers;

namespace Promomash.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUserAsync([FromBody] CreateUserCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);

                return Ok(new { message = "Registration successful" });
            }
            return BadRequest(ModelState);
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<GetUsersResponse>>> GetUsersAsync()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            if (users == null || users.Count == 0)
            {
                return NotFound(new { message = "No users found" });
            }
            return Ok(users);
        }

        [HttpGet("countries")]
        public ActionResult<IEnumerable<object>> GetCountries()
        {
            var countries = new List<object>
            {
                new { Id = 1, Name = "Country 1" },
                new { Id = 2, Name = "Country 2" }
            };
            return Ok(countries);
        }

        [HttpGet("provinces/{countryId}")]
        public ActionResult<IEnumerable<object>> GetProvinces(int countryId)
        {
            var provinces = new List<object>();
            if (countryId == 1)
            {
                provinces = new List<object>
                {
                    new { Id = "1.1", Name = "Province 1.1" },
                    new { Id = "1.2", Name = "Province 1.2" }
                };
            }
            else if (countryId == 2)
            {
                provinces = new List<object>
                {
                    new { Id = "2.1", Name = "Province 2.1" },
                    new { Id = "2.2", Name = "Province 2.2" }
                };
            }
            return Ok(provinces);
        }
    }
}
