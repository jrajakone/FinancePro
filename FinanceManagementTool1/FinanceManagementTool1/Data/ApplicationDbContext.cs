using FinanceManagementTool1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementTool1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
			
        }

		public DbSet<AddData> addDatas { get; set; }
	}


	// Features: Einnahmen/Ausgaben Hinzufügen
	/*public class AppDbContext : DbContext
	{
		protected readonly IConfiguration Configuration;
		public AppDbContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"));
		}

		public DbSet<AddData> addDatas { get; set; }
	}*/
}
