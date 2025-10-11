using Demo.DAL.Data.Contexts;
using Demo.DAL.Data.Repository;
using Demo.PLL.Mappings;
using Demo.PLL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.presentation
{
    public class Program
    {
        public static void Main(string[] args) { 
        
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //??Let`s inject life itme
            ///
            builder.Services.AddDbContext<APP_1>(option => option.UseSqlServer(

                                //  builder.Configuration["ConnectionString=DefulatConnectionString"])
                                builder.Configuration.GetConnectionString("DefaultConnectionString")
            ));

            // builder.Services.AddScoped<IDepartemntRepository,DepartemntRepository>();
            builder.Services.AddScoped<EmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<EmployeeService, EmployeeService>();

            builder.Services.AddAutoMapper(map => map.AddProfile(new MapProfile()));
            var app = builder.Build();

           
          //  builder.Services.AddAutoMapper(C=>C.AddMaps (  typeof(MapProfile).Assembly));

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
                pattern: "{controller=Employee}/{action=Index}");

            app.Run();
        }
    }
}
