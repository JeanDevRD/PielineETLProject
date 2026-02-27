
using ETLProject.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETLProject.Infrastructure.Persistence.EntityConfiguration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(od => od.Id);

            builder.Property(od => od.Id)
                .HasColumnName("OrderDetailID")
                .ValueGeneratedOnAdd(); 

            builder.Property(od => od.OrderID)
                .IsRequired();

            builder.Property(od => od.ProductID)
                .IsRequired();

            builder.Property(od => od.Quantity)
                .IsRequired();

            builder.Property(od => od.TotalPrice)
                .IsRequired()
                .HasColumnType("DECIMAL(10,2)");

            builder.HasIndex(od => new { od.OrderID, od.ProductID })
                .IsUnique()
                .HasDatabaseName("UQ_OrderDetails_Order_Product");

            builder.HasIndex(od => od.OrderID)
                .HasDatabaseName("IX_OrderDetails_OrderID");

            builder.HasIndex(od => od.ProductID)
                .HasDatabaseName("IX_OrderDetails_ProductID");

            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderDetails_Orders");

            builder.HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_OrderDetails_Products");

        }
    }
    
}
