using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations;

public class RewardConfiguration : IEntityTypeConfiguration<Reward>
{
    public void Configure(EntityTypeBuilder<Reward> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.CreateTime)
            .HasDefaultValueSql("GETDATE()");

        builder
            .Property(x => x.UpdateTime)
            .HasDefaultValueSql("GETDATE()");

        builder
            .HasMany(x => x.StudentRewards)
            .WithOne(x => x.Reward)
            .HasForeignKey(x => x.RewardId);
    }
}