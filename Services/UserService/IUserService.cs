using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_user.Dtos.User;
using dotnet_user.Models;

namespace dotnet_user.Services.UserService
{
    public interface IUserService
    {
        Task<List<GetUserDto>> GetAllUsers();
        Task<GetUserDto> GetUserByID(int id);
        Task<List<GetUserDto>> AddUser(AddUserDto newUser);
        Task<GetUserDto> UpdateUser(UpdateUserDto updatedUser);

        Task<List<GetUserDto>> DeleteUser(int id);
    }
}