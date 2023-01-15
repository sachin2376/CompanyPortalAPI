using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApiWithSqliteDB.DataModels
{
    public class EmployeeDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Company> Company { get; set; }

        public EmployeeDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(configuration.GetConnectionString("CS"));
        }
    }
}
