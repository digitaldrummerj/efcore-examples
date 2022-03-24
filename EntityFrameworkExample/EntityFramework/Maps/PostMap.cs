using EntityFrameworkExample.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkExample.Maps;

public class PostMap : EntityMapBase<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        base.Configure(builder);
    }
}