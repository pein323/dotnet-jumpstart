using Microsoft.AspNetCore.Mvc;

namespace dotnet_jumpstart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static readonly Character knight = new();

        [HttpGet]
        public ActionResult<Character> Get()
        {
            return Ok(knight);
        }
    }
}