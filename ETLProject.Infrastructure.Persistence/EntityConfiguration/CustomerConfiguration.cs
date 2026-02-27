using ETLProject.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETLProject.Infrastructure.Persistence.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("CustomerID")
                .ValueGeneratedNever();

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(c => c.Phone)
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)");


            builder.Property(c => c.CityID)
                .IsRequired();

            builder.HasIndex(c => c.Email)
                .IsUnique()
                .HasDatabaseName("UQ_Customers_Email");

            builder.HasIndex(c => c.CityID)
                .HasDatabaseName("IX_Customers_CountryID");
       
            builder.HasOne(c => c.City)
                .WithMany(co => co.Customers)
                .HasForeignKey(c => c.CityID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Customers_Cities");

      
            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Orders_Customers");
        }
    }
}
