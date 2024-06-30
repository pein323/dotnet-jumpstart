using AutoMapper;
using dotnet_jumpstart.DTOs.Character;

namespace dotnet_jumpstart.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        public IMapper _mapper { get; }
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static readonly List<Character> characters = new List<Character> {
            new Character(),
            new Character {
                Id = 1,
                Name = "Dzoana"
            }
        };


        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDto>> { Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList() };
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var result = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(result);
            return serviceResponse;
        }
    }
}