using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_user.Dtos.User;
using dotnet_user.Models;
using dotnet_user.Services;
using dotnet_user.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_user.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _userService.GetUserByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDto newUser)
        { 
            await _userService.AddUser(newUser);
            return Ok(await _userService.GetAllUsers());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updatedUser)
        { 
            GetUserDto usr = await _userService.UpdateUser(updatedUser);
            if (usr == null)
            {
                return NotFound();
            }
            return Ok(usr);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            List<GetUserDto> res = await _userService.DeleteUser(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

    }

}