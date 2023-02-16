using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.CertificatePurchases)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId);

        builder
            .HasMany(x => x.MoneyTransfersFromStudent)
            .WithOne(x => x.StudentFrom)
            .HasForeignKey(x => x.StudentFromId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.MoneyTransfersToStudent)
            .WithOne(x => x.StudentTo)
            .HasForeignKey(x => x.StudentToId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.StudentRewards)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId);
    }
}