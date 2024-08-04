using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Entities;

namespace TaskManagementAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Story> Stories { get; set; }
    }
}
