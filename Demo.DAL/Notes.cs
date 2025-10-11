#region Notes

using Demo.DAL.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
#region DI

////services.AddScoped<AppDbContext>();
////Internally, it does not create an AppDbContext yet. It basically:

////csharp
////Copy code
////services.Add(new ServiceDescriptor(
////    ServiceType: typeof(AppDbContext),
////    ImplementationType: typeof(AppDbContext),
////    Lifetime: ServiceLifetime.Scoped
////));
///  public class Program
//{
//        public static void Main(string[] args)
//{
//    var builder = WebApplication.CreateBuilder(args);

//    // Add services to the container.
//    builder.Services.AddControllersWithViews();


//    //📌Let`s inject life itme
//    ///
//    builder.Services.AddDbContext<APP_1>(option => option.UseSqlServer(



//                        //  builder.Configuration["ConnectionString=DefulatConnectionString"])

//                        builder.Configuration.GetConnectionString("DefaultConnectionString")


//    ));
//    var app = builder.Build();

//    // Configure the HTTP request pipeline.
//    if (!app.Environment.IsDevelopment())
//    {
//        app.UseExceptionHandler("/Home/Error");
//        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//        app.UseHsts();
//    }

//    app.UseHttpsRedirection();
//    app.UseStaticFiles();

//    app.UseRouting();

//    app.UseAuthorization();

//    app.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");

//    app.Run();
//}
//    }
//}


#endregion


#endregion