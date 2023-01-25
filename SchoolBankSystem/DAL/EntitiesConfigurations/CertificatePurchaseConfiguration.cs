using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations;

public class CertificatePurchaseConfiguration : IEntityTypeConfiguration<CertificatePurchase>
{
    public void Configure(EntityTypeBuilder<CertificatePurchase> builder)
    {
        builder.HasKey(x => x.Id);
    }
}