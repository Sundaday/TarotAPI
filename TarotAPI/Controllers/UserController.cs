using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarotAPI.DTOs;
using TarotAPI.DTOs.Get;
using TarotAPI.Models;
using TarotAPI.Services.Contract;
using TarotAPI.Utilities;

namespace TarotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            ResponseApi<List<UserDto>> responseApi = new ResponseApi<List<UserDto>>() { Status = false, Msg = "" };
            try
            {
                List<User> userList = await _userService.GetUserList();
                if (userList.Count > 0)
                {
                    List<UserDto> dtoList = _mapper.Map<List<UserDto>>(userList);
                    responseApi = new ResponseApi<List<UserDto>> { Status = true, Msg = "Ok", Value = dtoList };
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            ResponseApi<UserDto> responseApi = new ResponseApi<UserDto>() { Status = false, Msg = "" };
            try
            {
                User user = await _userService.GetUserById(id);
                if (id != 0)
                {
                    UserDto dto = _mapper.Map<UserDto>(user);
                    responseApi = new ResponseApi<UserDto> { Status = true, Msg = "Ok", Value = dto };
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

        [HttpGet("WithGuild")]
        public async Task<IActionResult> GetUserListWithGuild()
        {
            ResponseApi<List<GetUserWithGuildDto>> responseApi = new ResponseApi<List<GetUserWithGuildDto>>() { Status = false, Msg = "" };
            try
            {
                List<User> userList = await _userService.GetUserListWithGuild();
                if (userList.Count > 0)
                {
                    List<GetUserWithGuildDto> dtoList = _mapper.Map<List<GetUserWithGuildDto>>(userList);
                    responseApi = new ResponseApi<List<GetUserWithGuildDto>> { Status = true, Msg = "Ok", Value = dtoList };
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

        [HttpGet("WithGuild/{id}")]
        public async Task<IActionResult> GetUserByIdWithGuild(int id)
        {
            ResponseApi<GetUserWithGuildDto> responseApi = new ResponseApi<GetUserWithGuildDto>() { Status = false, Msg = "" };
            try
            {
                User user = await _userService.GetUserByIdWithGuild(id);
                if (id != 0)
                {
                    GetUserWithGuildDto dto = _mapper.Map<GetUserWithGuildDto>(user);
                    responseApi = new ResponseApi<GetUserWithGuildDto> { Status = true, Msg = "Ok", Value = dto };
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

        [HttpPost]
        public async Task<IActionResult> CreateUser(GetUserWithGuildDto request)
        {
            ResponseApi<GetUserWithGuildDto> responseApi = new ResponseApi<GetUserWithGuildDto>() { Status = false, Msg = "" };
            try
            {
                User _model = _mapper.Map<User>(request);
                User _userCreated = await _userService.AddUser(_model);
                if (_userCreated.UserId != 0)
                {
                    responseApi = new ResponseApi<GetUserWithGuildDto>
                    {
                        Status = true,
                        Msg = "Ok",
                        Value = _mapper.Map<GetUserWithGuildDto>(_userCreated)
                    };
                }
                else
                {
                    responseApi.Msg = "User could not be created";
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
        public async Task<IActionResult> UpdateUser(GetUserWithGuildDto request)
        {
            ResponseApi<GetUserWithGuildDto> responseApi = new ResponseApi<GetUserWithGuildDto>() { Status = false, Msg = "" };
            try
            {
                User _model = _mapper.Map<User>(request);
                User _userEdited = await _userService.UpdateUser(_model);
                if (_userEdited.UserId != 0)
                {
                    responseApi = new ResponseApi<GetUserWithGuildDto>
                    {
                        Status = true,
                        Msg = "Ok",
                        Value = _mapper.Map<GetUserWithGuildDto>(_userEdited)
                    };
                }
                else
                {
                    responseApi.Msg = "User could not be edited";
                }
                return Ok(responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Msg = ex.Message;
                return BadRequest(responseApi);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            ResponseApi<bool> responseApi = new ResponseApi<bool>() { Status = false, Msg = "" };
            try
            {
                User _userFound = await _userService.GetUserByIdWithGuild(id);
                bool deleted = await _userService.DeleteUser(_userFound);
                if (deleted)
                {
                    responseApi = new ResponseApi<bool> { Status = true, Msg = "Ok" };
                }
                else
                {
                    responseApi.Msg = "User not found";
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