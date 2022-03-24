using EntityFrameworkExample.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkExample.Maps;

public abstract class EntityMapBase<TEntity> : IEntityMap<TEntity> where TEntity : class, IEntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // builder.HasQueryFilter(t => t.IsDeleted == false);
    }
}