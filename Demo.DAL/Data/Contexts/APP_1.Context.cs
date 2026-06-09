using Demo.DAL.Data.Configuration;
using Demo.DAL.Emp_Module;
using Demo.DAL.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Contexts
{
      //  public EmployeeRepository(APP_1 _app) : base(APP_1)
    public class APP_1 : IdentityDbContext<ApplicationUser>
    {

        public APP_1(DbContextOptions options):base(options){}


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}
        protected override void OnModelCreating(ModelBuilder configurationBuilder) {

            // configurationBuilder.ApplyConfiguration<Departemnt>(new Department_confg());
       configurationBuilder.ApplyConfiguration<Employee>(new Employee_Confg());

            // configurationBuilder.ApplyConfigurationsFromAssembly( Assembly.GetExecutingAssembly());
            // configurationBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(configurationBuilder);


         //or  use it when cntext and  conf in same proJECT
         //  configurationBuilder.ApplyConfigurationsFromAssembly(typeof(".YOUR CONFG.").Assembly);
         //AS  THEY  DO  [go to the project that definded this confg]
        }
        DbSet<Departemnt> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }




    }
}
