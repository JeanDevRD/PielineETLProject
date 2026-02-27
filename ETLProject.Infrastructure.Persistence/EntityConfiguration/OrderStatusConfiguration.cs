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
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder) 
        {
            builder.ToTable("OrderStatus");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("StatusID")
                .ValueGeneratedOnAdd(); 

            builder.Property(s => s.StatusName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)");

            builder.HasIndex(s => s.StatusName)
                .IsUnique()
                .HasDatabaseName("UQ_OrderStatus_Name");

            builder.HasMany(s => s.Orders)
                .WithOne(o => o.Status)
                .HasForeignKey(o => o.StatusID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Orders_OrderStatus");
        }
        
    }
}
