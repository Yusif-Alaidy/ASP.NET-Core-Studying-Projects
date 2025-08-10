using Microsoft.EntityFrameworkCore;
using Task_project.Models;

namespace Task_project.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=.; database=DoctorsDb; trusted_connection=true; trustservercertificate=true;");

        }
    }
}
