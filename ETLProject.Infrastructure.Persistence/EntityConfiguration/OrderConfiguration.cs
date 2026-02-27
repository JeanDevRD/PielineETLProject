using ETLProject.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETLProject.Infrastructure.Persistence.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("OrderID")
                .ValueGeneratedNever(); 

            builder.Property(o => o.CustomerID)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired()
                .HasColumnType("DATE");

            builder.Property(o => o.StatusID)
                .IsRequired();

            builder.HasIndex(o => o.CustomerID)
                .HasDatabaseName("IX_Orders_CustomerID");

            builder.HasIndex(o => o.StatusID)
                .HasDatabaseName("IX_Orders_StatusID");

            builder.HasIndex(o => o.OrderDate)
                .HasDatabaseName("IX_Orders_OrderDate");

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Orders_Customers");

            builder.HasOne(o => o.Status)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StatusID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Orders_OrderStatus");

            builder.HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderDetails_Orders");
        }
    }
}
