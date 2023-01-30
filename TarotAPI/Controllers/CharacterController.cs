using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TarotAPI.DTOs;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;
using TarotAPI.Utilities;

namespace TarotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharactersList()
        {
            ResponseApi<List<CharacterDto>> responseApi = new ResponseApi<List<CharacterDto>>() { Status = false, Msg = "" };
            List<Character> charactersList = await _characterRepository.GetCharacters();
            try
            {
                if (charactersList.Count > 0)
                {
                    List<CharacterDto> dtoList = _mapper.Map<List<CharacterDto>>(charactersList);
                    responseApi = new ResponseApi<List<CharacterDto>> { Status = true, Msg = "Ok", Value = dtoList };
                }
                else
                {
                    responseApi.Msg = "No Data";
                }
                return Ok(responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Msg = ex.Message;
                return BadRequest(responseApi);
            }
        }
    }
}