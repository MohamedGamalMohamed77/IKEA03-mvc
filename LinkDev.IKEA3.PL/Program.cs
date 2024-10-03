using LinkDev.IKEA3.BLL.Common.Services.Attachments;
using LinkDev.IKEA3.BLL.Services.Departments;
using LinkDev.IKEA3.BLL.Services.Employees;
using LinkDev.IKEA3.DAL.Models.Identities;
using LinkDev.IKEA3.DAL.Presistance.Data;
using LinkDev.IKEA3.DAL.Presistance.Repositories.Departments;
using LinkDev.IKEA3.DAL.Presistance.Repositories.Employees;
using LinkDev.IKEA3.DAL.Presistance.UnitOfWork;
using LinkDev.IKEA3.PL.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.IKEA3.PL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region Configure Services
			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<ApplicationDbContext>((optionsBuilder) =>
			{
				optionsBuilder.UseLazyLoadingProxies()
				.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			//builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

			builder.Services.AddScoped<IDepartmentService, DepartmentService>();
			builder.Services.AddScoped<IEmployeeService, EmployeeService>();

			builder.Services.AddControllers();
			builder.Services.AddTransient<IAttachmentService, AttachmentService>();

			builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>((options) =>
			{
				options.Password.RequiredLength = 5;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequiredUniqueChars = 1;

				options.User.RequireUniqueEmail = true;

				options.Lockout.AllowedForNewUsers = true;
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);




			})
				.AddEntityFrameworkStores < ApplicationDbContext>();

			builder.Services.ConfigureApplicationCookie((options)=>
			{ 
				options.LoginPath="/Account/SignIn";
				options.AccessDeniedPath = "/Home/Error";
				options.ExpireTimeSpan = TimeSpan.FromDays(1);
				options.LogoutPath = "/Account/SignIn";

			});
			builder.Services.AddAuthentication((options)=>
			{
				options.DefaultAuthenticateScheme = "Identity.Application";
				options.DefaultChallengeScheme = "Identity.Application";

			}
			);

			#endregion

			builder.Logging.AddConsole();
			var app = builder.Build();

			#region Configure Kestral Middlewares


			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
			app.UseAuthentication();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			#endregion

			app.Run();
		}
	}
}
