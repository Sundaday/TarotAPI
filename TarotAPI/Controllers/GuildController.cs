using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarotAPI.DTOs;
using TarotAPI.Models;
using TarotAPI.Services.Contract;
using TarotAPI.Utilities;

namespace TarotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuildController : ControllerBase
    {
        private readonly IGuildService _guildService;
        private readonly IMapper _mapper;

        public GuildController(IGuildService guildService, IMapper mapper)
        {
            _guildService = guildService;
            _mapper = mapper;
        }

        #region GetGuildList
        [HttpGet]
        public async Task<IActionResult> GetGuildList()
        {
            ResponseApi<List<GuildDto>> responseApi = new ResponseApi<List<GuildDto>>() { Status = false, Msg = "" };
            try
            {
                List<Guild> guildList = await _guildService.GetGuilds();
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