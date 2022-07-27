using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        NorthwindContext nwcontext = new NorthwindContext();
        [HttpGet("GetByCountry")]
        public List<Customer> GetByCountry(string country)
        {
            return nwcontext.Customers.Where(o => o.Country == country).ToList();
        }

        [HttpGet("GetByCompanyName")]
        public Customer GetByCompanyName(string name)
        {
            return nwcontext.Customers.FirstOrDefault(o => o.CompanyName == name);
        }

        [HttpPost("AddCustomer")]
        public Customer AddCustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            Customer newCust = new Customer()
            {
                CustomerId = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };
            nwcontext.Customers.Add(newCust);
            nwcontext.SaveChanges();
            return newCust;
        }
    }
}
