using ETLProject.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETLProject.Infrastructure.Persistence.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("CategoryID")
                .ValueGeneratedOnAdd(); 

            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)");

            builder.HasIndex(c => c.CategoryName)
                .IsUnique()
                .HasDatabaseName("UQ_Categories_Name");

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Products_Categories");
        }
    }
}
