using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations;

public class MoneyTransferConfiguration : IEntityTypeConfiguration<MoneyTransfer>
{
    public void Configure(EntityTypeBuilder<MoneyTransfer> builder)
    {
        builder.HasKey(x => x.Id);
    }
}