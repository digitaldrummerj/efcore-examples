using EntityFrameworkExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkExample.Maps;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasQueryFilter(t => t.IsDeleted == false);

        builder.HasIndex(t => t.Title);

        builder.HasIndex(t => t.Url)
            .IsUnique();

        builder.HasIndex(t => new { t.Title, t.Url });
    }
}