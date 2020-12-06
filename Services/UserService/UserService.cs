using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_user.Data;
using dotnet_user.Dtos.User;
using dotnet_user.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_user.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<GetUserDto>> AddUser(AddUserDto newUser)
        {
            User usr = _mapper.Map<User>(newUser);
            await _context.Users.AddAsync(usr);
            await _context.SaveChangesAsync();
            return (_context.Users.Select(u => _mapper.Map<GetUserDto>(u))).ToList();
        }

        public async Task<List<GetUserDto>> GetAllUsers()
        {
            List<User> dbUsers =await _context.Users.ToListAsync();
            return (dbUsers.Select(u => _mapper.Map<GetUserDto>(u))).ToList();
        }

        public async Task<GetUserDto> GetUserByID(int id)
        {
            User dbUser =await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<GetUserDto>(dbUser);
        }

        public async Task<GetUserDto> UpdateUser(UpdateUserDto updatedUser)
        {
            User usr =await  _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            try
            {
                usr.name = updatedUser.name;
                usr.mobileNo = updatedUser.mobileNo;
                usr.usrType = updatedUser.usrType;
                _context.Users.Update(usr);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return _mapper.Map<GetUserDto>(usr);

        }

        public async Task<List<GetUserDto>> DeleteUser(int id)
        {

            try
            {
                User usr = await _context.Users.FirstAsync(u => u.Id == id);
                _context.Users.Remove(usr);
                await _context.SaveChangesAsync();
                return (_context.Users.Select(u => _mapper.Map<GetUserDto>(u))).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
            //return _mapper.Map<GetUserDto>(usr);
        }
    }
}