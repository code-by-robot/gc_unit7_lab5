using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        NorthwindContext nwcontext = new NorthwindContext();

        [HttpGet("GetByFirstName")]
        public List<Employee> GetByFirstName(string name)
        {
            return nwcontext.Employees.Where(o => o.FirstName == name).ToList();
        }

        [HttpGet("GetByCountry")]
        public List<Employee> GetByCountry(string country)
        {
            return nwcontext.Employees.Where(o => o.Country == country).ToList();
        }



    }
}
