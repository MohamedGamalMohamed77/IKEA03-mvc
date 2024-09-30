using LinkDev.IKEA3.DAL.Models.Departments;
using LinkDev.IKEA3.DAL.Models.Employees;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//=> optionsBuilder.UseSqlServer("Server= . ; Database = MVCApplication3G01; Trusted_Connection= True; TrustServerCertificate=True ; MultipleActiveResultSets = True ; Encrypt= False ; ");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{ 
			base.OnModelCreating(modelBuilder); 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }
	}
}
