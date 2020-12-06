using System;
using dotnet_user.Models;

namespace dotnet_user.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set; } = 0;
        public string name { get; set; } = "Omar";
        public string mobileNo { get; set; } = "0599172168";
        public UserType usrType { get; set; } = UserType.Student;
    }
}