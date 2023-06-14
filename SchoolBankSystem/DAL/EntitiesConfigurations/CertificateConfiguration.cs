using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.CreateTime)
            .HasDefaultValueSql("GETDATE()");

        builder
            .Property(x => x.UpdateTime)
            .HasDefaultValueSql("GETDATE()");

        builder
            .HasMany(x => x.CertificatePurchases)
            .WithOne(x => x.Certificate)
            .HasForeignKey(x => x.CertificateId);
    }
}