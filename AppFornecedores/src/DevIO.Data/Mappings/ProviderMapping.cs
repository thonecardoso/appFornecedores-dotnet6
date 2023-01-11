using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

public class ProviderMapping : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Document)
            .IsRequired()
            .HasColumnType("varchar(14)");

        // 1 : 1 => Provider : Address
        builder.HasOne(p => p.Address)
            .WithOne(a => a.Provider);

        // 1 : N => Provider : Productors
        builder.HasMany(p => p.Products)
            .WithOne(p => p.Provider)
            .HasForeignKey(p => p.ProviderId);

        builder.ToTable("Providers");
    }
}