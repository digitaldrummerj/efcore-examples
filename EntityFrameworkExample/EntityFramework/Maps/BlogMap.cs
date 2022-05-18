using EntityFrameworkExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkExample.Maps;

public class BlogMap : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasQueryFilter(t => t.IsDeleted == false);

        builder.HasIndex(t => t.Url)
            .IsUnique();

        builder.Property(s => s.Status)
            .HasDefaultValue(Status.Draft)
            .HasConversion<string>();
    }
}