using Auth_tutorial.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth_tutorial.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
