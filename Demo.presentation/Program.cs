using Demo.DAL.Data.Contexts;
using Demo.DAL.Data.Repository;
using Demo.DAL.Shared;
using Demo.PLL.Mappings;
using Demo.PLL.Services;
using Demo.PLL.Services.Attachments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;

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
            builder.Services.AddDbContext<APP_1>(option => option.UseNpgsql(

                                //  builder.Configuration["ConnectionString=DefulatConnectionString"])
                                builder.Configuration.GetConnectionString("DefaultConnectionString")
            ));

             builder.Services.AddScoped<IDepartemntRepository,DepartemntRepository>();
            //builder.Services.AddScoped<EmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<DepartmentServices,DepartmentServices>();    
            builder.Services.AddScoped<EmployeeService, EmployeeService>();

            builder.Services.AddScoped<IAttachment, AttachmentSerivce>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(map => map.AddProfile(new MapProfile()));


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                
                .AddEntityFrameworkStores<APP_1>();


            builder.Services.AddScoped<EmailSettings, EmailSettings>();
           
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register}");

            app.Run();
        }
    }
}
