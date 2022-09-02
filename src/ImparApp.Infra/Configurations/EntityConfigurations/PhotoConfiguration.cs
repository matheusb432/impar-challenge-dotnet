using ImparApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImparApp.Infra.Configurations.EntityConfigurations
{
    internal class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Base64);
            builder.HasOne(e => e.Card).WithOne(c => c.Photo);
        }
    }
}