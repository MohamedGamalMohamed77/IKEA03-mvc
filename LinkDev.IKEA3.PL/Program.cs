using LinkDev.IKEA3.BLL.Services.Departments;
using LinkDev.IKEA3.DAL.Presistance.Data;
using LinkDev.IKEA3.DAL.Presistance.Repositories.Departments;
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
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepositories>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddControllers();


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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
