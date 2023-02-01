using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarotAPI.DTOs;
using TarotAPI.DTOs.Get;
using TarotAPI.Models;
using TarotAPI.Repository.Interface;
using TarotAPI.Utilities;

namespace TarotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            await _userRepository.Add(user);
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            await _userRepository.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userRepository.Delete(user);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            ResponseApi<UserDto> responseApi = new ResponseApi<UserDto>() { Status = false, Msg = "" };
            try
            {
                User user = await _userRepository.GetById(id);
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

        //[HttpGet("WithGuild")]
        //public async Task<IActionResult> GetUserListWithGuild()
        //{
        //    ResponseApi<List<GetUserWithGuildDto>> responseApi = new ResponseApi<List<GetUserWithGuildDto>>() { Status = false, Msg = "" };
        //    try
        //    {
        //        List<User> userList = await _userRepository.GetUserListWithGuild();
        //        if (userList.Count > 0)
        //        {
        //            List<GetUserWithGuildDto> dtoList = _mapper.Map<List<GetUserWithGuildDto>>(userList);
        //            responseApi = new ResponseApi<List<GetUserWithGuildDto>> { Status = true, Msg = "Ok", Value = dtoList };
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

        //[HttpGet("WithGuild/{id}")]
        //public async Task<IActionResult> GetUserByIdWithGuild(int id)
        //{
        //    ResponseApi<GetUserWithGuildDto> responseApi = new ResponseApi<GetUserWithGuildDto>() { Status = false, Msg = "" };
        //    try
        //    {
        //        User user = await _userRepository.GetUserByIdWithGuild(id);
        //        if (id != 0)
        //        {
        //            GetUserWithGuildDto dto = _mapper.Map<GetUserWithGuildDto>(user);
        //            responseApi = new ResponseApi<GetUserWithGuildDto> { Status = true, Msg = "Ok", Value = dto };
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
        public async Task<IActionResult> CreateUser(GetUserWithGuildDto request)
        {
            ResponseApi<GetUserWithGuildDto> responseApi = new ResponseApi<GetUserWithGuildDto>() { Status = false, Msg = "" };
            try
            {
                User _model = _mapper.Map<User>(request);
                User _userCreated = await _userRepository.Add(_model);
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
                User _userEdited = await _userRepository.Update(_model);
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
        public async Task<IActionResult> DeleteUser1(int id)
        {
            ResponseApi<bool> responseApi = new ResponseApi<bool>() { Status = false, Msg = "" };
            try
            {
                User _userFound = await _userRepository.GetById(id);
                bool deleted = await _userRepository.Delete(_userFound);
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