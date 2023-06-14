using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = DAL.Entities.File;

namespace DAL.EntitiesConfigurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Students)
                .WithOne(x => x.Image)
                .HasForeignKey(x => x.ImageId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}