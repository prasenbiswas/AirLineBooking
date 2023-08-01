using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCTest.DbContext;
using MVCTest.Models;
using MVCTest.Repository;

namespace MVCTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var _Configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString")));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            builder.Services.ConfigureApplicationCookie(Config =>
            {
                Config.LoginPath = _Configuration["Application:LoginPath"];
            });
            builder.Services.AddScoped<IGenericRepository<Flight>,GenericRepository<Flight>>();
            builder.Services.AddScoped<IGenericRepository<Passenger>,GenericRepository<Passenger>>();
            var app = builder.Build();

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
            app.UseAuthentication();
            app.UseAuthorization();
                                                                                            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}