using HelloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HelloWebAPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetMessage()
        {
            
            var result = new ResponseModel(
               200, "Hello Web API");

            /*
            - eğer başarılı ise böyle döndürürüz : return Ok(result);
            - eğer hatalı ise böyle döndürürüz : return BadRequest(result);
            - eğer aranan kaynak bulunamadı ise böyle döndürürüz : return NotFound(result);
             */

            return Ok(result);
        }
    }
}
