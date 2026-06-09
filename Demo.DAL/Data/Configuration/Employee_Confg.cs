 using Demo.DAL.Emp_Module;
using Demo.DAL.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.DAL.Data.Configuration
{
    internal class Employee_Confg :  BaseConfg<Employee>,  IEntityTypeConfiguration<Employee> 
    {

        //not allowed public bec  when explecit so call from interface only
         void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
        {

            base.Configure(builder);
            builder.Property(e => e.id);
            builder.Property(e=>e.Name);
            builder.Property(e => e.Type).HasConversion((type) => type.ToString(),
                (type) => (Employe_Type)Enum.Parse(typeof(Employe_Type),type));

            builder.Property(e => e.gender).HasConversion((type) => type.ToString(),

              (Empl_gender) => (Gender)Enum.Parse(typeof(Gender), Empl_gender));


           // builder.Ignore(e => e.DepartmentID);

           builder.HasOne(e=>e.departemnt).WithMany(d=>d.Employees).HasForeignKey(e=>e.departmentiD);


              




        }
    }
}
