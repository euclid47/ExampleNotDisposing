using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExampleNotDisposing.Models
{
    public class CompanyDbContext : DbContext
    {
		public DbSet<Company> Companies { get; set; }

		public DbSet<Employee> Employees { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
			var builder = new ConfigurationBuilder().AddJsonFile($"{Directory.GetCurrentDirectory()}/secrets.json");
			var configuration = builder.Build();
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
			optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionStrings")[environment]);
		}
    }
}
