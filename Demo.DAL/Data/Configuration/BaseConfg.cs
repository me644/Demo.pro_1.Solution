using Demo.DAL.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.DAL.Data.Configuration
{
    internal class BaseConfg<T> : IEntityTypeConfiguration<T> where T : Base_Entity
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {

            builder.Property(e => e.Created_oN).HasDefaultValueSql("Current_TIMESTAMP");

            builder.Property(e => e.Modified_oN).HasDefaultValueSql("Current_TIMESTAMP");

        }
    }
}
