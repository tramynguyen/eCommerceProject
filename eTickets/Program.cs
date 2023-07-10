using eTickets.Data;
using eTickets.Data.Services;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eTickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
            IWebHostEnvironment environment = builder.Environment;
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            //Services configuration
            builder.Services.AddScoped<IActorService, ActorsService>();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



            //seed database
            AppDbInitializer.Seed(app);
            app.Run();

        }
    }
}
