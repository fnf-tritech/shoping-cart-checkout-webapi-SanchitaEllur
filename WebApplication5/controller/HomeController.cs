using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
       private readonly Checkout checkout;
            public HomeController()
        {
            checkout = new Checkout();
        }
        [HttpPost("scan")]
        public IActionResult ScanItem([FromBody]char itemSKU) 
        {
            checkout.Scan(itemSKU);
            return Ok();
        }
        [HttpGet("total")]
        public IActionResult GetTotalPrice()
        {
            int totalPrice = checkout.CalculateTotalPrice();
            return Ok(totalPrice);
        }
    }
}
