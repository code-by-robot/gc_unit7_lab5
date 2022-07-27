using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrdersController : ControllerBase
    {
        NorthwindContext nwcontext = new NorthwindContext();

        [HttpGet("GetByCustomerId")]
        public List<Order> GetByCustomerId(string custId)
        {
            return nwcontext.Orders.Where(o => o.CustomerId ==custId).ToList();
        }

        [HttpGet("GetByOrderId")]
        public Order GetByCustomerId(int orderId)
        {
            return nwcontext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        [HttpPost("AddOrder")]
        public Order AddOrder(string custId, int empId, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, int shipVia, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, int shipPostCode, string shipCountry )
        {
            Order newOrder = new Order()
            {
                CustomerId = custId,
                EmployeeId = empId,
                OrderDate = orderDate,
                RequiredDate = requiredDate,
                ShippedDate = shippedDate,
                ShipVia = shipVia,
                Freight = freight,
                ShipName = shipName,
                ShipAddress = shipAddress,
                ShipCity = shipCity,
                ShipRegion = shipRegion,
                ShipCountry = shipCountry,
            };
            nwcontext.Orders.Add(newOrder);
            nwcontext.SaveChanges();
            return newOrder;
        }
    }
}
