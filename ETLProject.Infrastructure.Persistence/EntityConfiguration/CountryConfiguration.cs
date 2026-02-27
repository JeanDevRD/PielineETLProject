using ETLProject.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETLProject.Infrastructure.Persistence.EntityConfiguration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("CountryID")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CountryName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.HasIndex(c => c.CountryName)
                .IsUnique()
                .HasDatabaseName("UQ_Countries_Name");

            builder.HasMany(c => c.Cities)
                .WithOne(cu => cu.Country)
                .HasForeignKey(cu => cu.CountryID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Cities_Countries");
        }
    }
}
