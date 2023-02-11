using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CompanyProject.DataModels
{
    public class CompanyDbContext:DbContext
    {
        private readonly IConfiguration configuration;

        public CompanyDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<Company>  Company { get; set; }
        public virtual DbSet<Client>  Client { get; set; }
        public virtual DbSet<Project>  Project { get; set; }
        public virtual DbSet<Employee>  Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string str = configuration.GetConnectionString("CS");
            options.UseSqlite(configuration.GetConnectionString("CS"));
        }
    }
}
