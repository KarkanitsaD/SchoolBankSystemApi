using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations;

public class StudentRewardConfiguration : IEntityTypeConfiguration<StudentReward>
{
    public void Configure(EntityTypeBuilder<StudentReward> builder)
    {
        builder.HasKey(x => x.Id);
    }
}