using System;

namespace dotnet_user.Models
{
    public class User
    {
        public int Id { get; set; } = 0;
        public String name { get; set; } = "Omar";
        public string mobileNo { get; set; } = "0599172168";
        public UserType usrType { get; set; } = UserType.Student;
        
    }
}