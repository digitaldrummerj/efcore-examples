using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample.Maps;

public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{

}