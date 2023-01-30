using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarotAPI.DTOs;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;
using TarotAPI.Utilities;

namespace TarotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuildController : ControllerBase
    {
        private readonly IGuildRepository _guildRepository;
        private readonly IMapper _mapper;

        public GuildController(IGuildRepository guildRepository, IMapper mapper)
        {
            _guildRepository = guildRepository;
            _mapper = mapper;
        }

        #region GetGuildList
        [HttpGet]
        public async Task<IActionResult> GetGuildList()
        {
            ResponseApi<List<GuildDto>> responseApi = new ResponseApi<List<GuildDto>>() { Status = false, Msg = "" };
            try
            {
                List<Guild> guildList = await _guildRepository.GetGuilds();
                if (guildList.Count > 0)
                {
                    List<GuildDto> dtoList = _mapper.Map<List<GuildDto>>(guildList);
                    responseApi = new ResponseApi<List<GuildDto>> { Status = true, Msg = "Ok", Value = dtoList };
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
        #endregion
    }
}