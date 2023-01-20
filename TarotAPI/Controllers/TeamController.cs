using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarotAPI.DTOs;
using TarotAPI.DTOs.Get;
using TarotAPI.DTOs.Post;
using TarotAPI.Models;
using TarotAPI.Services.Contract;
using TarotAPI.Services.Implementation;
using TarotAPI.Utilities;

namespace TarotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TeamController(ITeamService teamService, IUserService userService, IMapper mapper)
        {
            _teamService = teamService;
            _userService = userService;
            _mapper = mapper;
        }

        #region GetTeamListWithCharacters
        [HttpGet("WithCharacters")]
        public async Task<IActionResult> GetTeamListWithCharacters(int id)
        {
            ResponseApi<List<GetTeamWithCharactersDto>> responseApi = new ResponseApi<List<GetTeamWithCharactersDto>>() { Status = false, Msg = "" };
            try
            {
                List<Team> teamList = await _teamService.GetTeamsWithCharactersList(id);
                if (teamList.Count > 0)
                {
                    List<GetTeamWithCharactersDto> dtoList = _mapper.Map<List<GetTeamWithCharactersDto>>(teamList);
                    responseApi = new ResponseApi<List<GetTeamWithCharactersDto>> { Status = true, Msg = "Ok", Value = dtoList };
                }
                else
                {
                    responseApi.Msg = "No Data";
                }
                return StatusCode(StatusCodes.Status200OK, responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Msg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseApi);
            }
        }
        #endregion

        #region GetTeamList
        [HttpGet]
        public async Task<IActionResult> GetTeamList()
        {
            ResponseApi<List<TeamDto>> responseApi = new ResponseApi<List<TeamDto>>() { Status = false, Msg = "" };
            try
            {
                List<Team> teamList = await _teamService.GetTeamsList();
                if (teamList.Count > 0)
                {
                    List<TeamDto> dtoList = _mapper.Map<List<TeamDto>>(teamList);
                    responseApi = new ResponseApi<List<TeamDto>> { Status = true, Msg = "Ok", Value = dtoList };
                }
                else
                {
                    responseApi.Msg = "No Data";
                }
                return StatusCode(StatusCodes.Status200OK, responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Msg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseApi);
            }
        }
        #endregion

        #region CreateTeam
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto request)
        {
            ResponseApi<CreateTeamDto> responseApi = new ResponseApi<CreateTeamDto>() { Status = false, Msg = "" };
            try
            {
                User user = await _userService.GetUserById(request.UserId);
                if (user != null)
                {
                    Team _model = _mapper.Map<Team>(request);
                    Team _teamCreated = await _teamService.CreateTeam(_model);
                    if (_teamCreated.TeamId != 0)
                    {
                        responseApi = new ResponseApi<CreateTeamDto>
                        {
                            Status = true,
                            Msg = "Ok",
                            Value = _mapper.Map<CreateTeamDto>(_teamCreated)
                        };
                    }
                }
                else
                {
                    responseApi.Msg = "User cannot be created";
                }
                return StatusCode(StatusCodes.Status200OK, responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Msg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseApi);
            }
        }
        #endregion

        #region UpdateTeam
        [HttpPut]
        public async Task<IActionResult> UpdateTeam (TeamDto request)
        {
            ResponseApi<TeamDto> responseApi = new ResponseApi<TeamDto>() { Status = false, Msg = "" };
            try
            {
                User user = await _userService.GetUserById(request.UserId);
                if(user != null)
                {
                    Team _model = _mapper.Map<Team>(request);
                    Team _teamUpdated = await _teamService.UpdateTeam(_model);
                    if(_teamUpdated.TeamId == _model.TeamId)
                    {
                        responseApi = new ResponseApi<TeamDto>
                        {
                            Status = true,
                            Msg = "Ok",
                            Value = _mapper.Map<TeamDto>(_teamUpdated)
                        };
                    }
                }
                else
                {
                    responseApi.Msg = "User cannot be updated";
                }
                return StatusCode(StatusCodes.Status200OK, responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Msg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseApi);
            }
        }
        #endregion
    }
}