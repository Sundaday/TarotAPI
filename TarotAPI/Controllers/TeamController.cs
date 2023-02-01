using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarotAPI.DTOs;
using TarotAPI.DTOs.Get;
using TarotAPI.DTOs.Post;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;
using TarotAPI.Utilities;

namespace TarotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public TeamController(IRepository<Team> teamRepository, IRepository<User> userRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //[HttpGet("WithCharacters")]
        //public async Task<IActionResult> GetTeamListWithCharacters(int id)
        //{
        //    ResponseApi<List<GetTeamWithCharactersDto>> responseApi = new ResponseApi<List<GetTeamWithCharactersDto>>() { Status = false, Msg = "" };
        //    try
        //    {
        //        List<Team> teamList = await _teamRepository.GetTeamsWithCharactersList(id);
        //        if (teamList.Count > 0)
        //        {
        //            List<GetTeamWithCharactersDto> dtoList = _mapper.Map<List<GetTeamWithCharactersDto>>(teamList);
        //            responseApi = new ResponseApi<List<GetTeamWithCharactersDto>> { Status = true, Msg = "Ok", Value = dtoList };
        //        }
        //        else
        //        {
        //            responseApi.Msg = "No Data";
        //        }
        //        return Ok(responseApi);
        //    }
        //    catch (Exception ex)
        //    {
        //        responseApi.Msg = ex.Message;
        //        return BadRequest(responseApi);
        //    }
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetTeamList()
        //{
        //    ResponseApi<List<TeamDto>> responseApi = new ResponseApi<List<TeamDto>>() { Status = false, Msg = "" };
        //    try
        //    {
        //        List<Team> teamList = await _teamRepository.GetTeamsList();
        //        if (teamList.Count > 0)
        //        {
        //            List<TeamDto> dtoList = _mapper.Map<List<TeamDto>>(teamList);
        //            responseApi = new ResponseApi<List<TeamDto>> { Status = true, Msg = "Ok", Value = dtoList };
        //        }
        //        else
        //        {
        //            responseApi.Msg = "No Data";
        //        }
        //        return Ok(responseApi);
        //    }
        //    catch (Exception ex)
        //    {
        //        responseApi.Msg = ex.Message;
        //        return BadRequest(responseApi);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto request)
        {
            ResponseApi<CreateTeamDto> responseApi = new ResponseApi<CreateTeamDto>() { Status = false, Msg = "" };
            try
            {
                User user = await _userRepository.GetById(request.UserId);
                if (user != null)
                {
                    Team _model = _mapper.Map<Team>(request);
                    Team _teamCreated = await _teamRepository.Add(_model);
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
                return Ok(responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Msg = ex.Message;
                return BadRequest(responseApi);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam (TeamDto request)
        {
            ResponseApi<TeamDto> responseApi = new ResponseApi<TeamDto>() { Status = false, Msg = "" };
            try
            {
                User user = await _userRepository.GetById(request.UserId);
                if(user != null)
                {
                    Team _model = _mapper.Map<Team>(request);
                    Team _teamUpdated = await _teamRepository.Update(_model);
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