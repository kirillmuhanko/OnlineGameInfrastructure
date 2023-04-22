using Microsoft.AspNetCore.Mvc;

namespace Common.Networking.Mvc.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    public abstract class PingControllerBase : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}