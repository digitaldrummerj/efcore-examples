using EntityFrameworkExample.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkExample.Maps;

public class BlogMap : EntityMapBase<Blog>
{
    public override void Configure(EntityTypeBuilder<Blog> builder)
    {
        base.Configure(builder);
    }
}