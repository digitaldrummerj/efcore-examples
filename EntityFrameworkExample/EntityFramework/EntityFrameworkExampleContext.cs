using EntityFrameworkExample.Entities;
using EntityFrameworkExample.Maps;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExample.Extensions;
namespace EntityFrameworkExample;

public class EntityFrameworkExampleContext : DbContext
{
    public EntityFrameworkExampleContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Blog> Blog { get; set; }

    public DbSet<Post> Post { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogMap());
        modelBuilder.ApplyConfiguration(new PostMap());
    }

    public override async  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.SetAuditProperties();
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        ChangeTracker.SetAuditProperties();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ChangeTracker.SetAuditProperties();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ChangeTracker.SetAuditProperties();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}