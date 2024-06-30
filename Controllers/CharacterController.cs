using dotnet_jumpstart.DTOs.Character;
using dotnet_jumpstart.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_jumpstart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("{id}")] // Not needed since naming convetnion see "Get" in method name. However it helps swagger
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get(int id) //When switched from Generic to typed ActionResult, then swagger can see the schema of response
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpGet("GetAll")]  
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetCharacters() //When switched from Generic to typed ActionResult, then swagger can see the schema of response
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}