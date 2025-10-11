using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configuration
{
    internal class Department_confg : BaseConfg<Departemnt>,IEntityTypeConfiguration<Departemnt>
    {
         void IEntityTypeConfiguration<Departemnt>.Configure(EntityTypeBuilder<Departemnt> builder)
        {
            builder.Property(d => d.id).UseIdentityColumn(10, 10);
            builder.Property(d => d.name).HasColumnType("varchar(20");
            builder.Property(d => d.code).HasColumnType("varchar(20");



           base.Configure(builder);

        }
    }


}
