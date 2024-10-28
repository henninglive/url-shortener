using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UrlShortener.Web.Database;

public class UrlEntityConfiguration : IEntityTypeConfiguration<UrlEntity>
{
    public void Configure(EntityTypeBuilder<UrlEntity> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Url)
            .IsRequired();
    }
}