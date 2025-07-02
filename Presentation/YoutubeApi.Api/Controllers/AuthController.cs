using Microsoft.AspNetCore.Mvc;

namespace YoutubeApi.Api.Controllers
{
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
