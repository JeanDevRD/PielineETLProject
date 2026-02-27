using ETLProject.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Infrastructure.Persistence.EntityConfiguration
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
    
        public void Configure(EntityTypeBuilder<City> builder) 
        {
            builder.ToTable("Cities");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("CityID")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CityName)
                .HasColumnName("CityName")
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.HasMany(c => c.Customers)
                .WithOne(c => c.City)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_City_Customers");


        }

    }
}
