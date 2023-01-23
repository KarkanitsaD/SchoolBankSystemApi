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
            .HasMany(x => x.CertificatePurchases)
            .WithOne(x => x.Certificate)
            .HasForeignKey(x => x.CertificateId);
    }
}