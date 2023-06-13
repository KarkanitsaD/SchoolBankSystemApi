using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Students)
                .WithOne(x => x.Class)
                .HasForeignKey(x => x.ClassId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
