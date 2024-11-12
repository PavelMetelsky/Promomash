using Microsoft.AspNetCore.Mvc;
using Promomash.Database;
using Promomash.Entities.User;

namespace Promomash.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly PromomashContext _context;

        public RegistrationController(PromomashContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(new { message = "Registration successful" });
            }
            return BadRequest(ModelState);
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
