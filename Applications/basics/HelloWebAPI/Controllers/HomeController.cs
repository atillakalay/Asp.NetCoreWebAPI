using HelloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel { HttpStatusCode = 404, Message = "Aradağınız sayfa bulunamadı!" };
            return Ok(result);
        }

    }
}
