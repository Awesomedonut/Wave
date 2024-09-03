using Microsoft.AspNetCore.Mvc;

namespace WavePlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("message")]
        public IActionResult GetMessage()
        {
            return Ok("hi from the .net backend");
        }
    }
}
