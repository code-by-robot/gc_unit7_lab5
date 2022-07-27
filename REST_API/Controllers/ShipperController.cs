using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        NorthwindContext nwcontext = new NorthwindContext();

        [HttpDelete("RemoveByShipperId{id}")]
        public Shipper RemoveByShipperId(int id)
        {
            Shipper toRemove = nwcontext.Shippers.FirstOrDefault(e => e.ShipperId == id);
            nwcontext.SaveChanges();
            return toRemove;
        }
    }
}
