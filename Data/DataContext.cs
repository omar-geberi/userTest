using dotnet_user.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_user.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}