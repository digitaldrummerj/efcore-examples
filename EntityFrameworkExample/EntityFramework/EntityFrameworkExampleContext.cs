using EntityFrameworkExample.Entities;
using EntityFrameworkExample.Maps;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExample.Extensions;
using EntityFrameworkExample.Authentication;

namespace EntityFrameworkExample;

public class EntityFrameworkExampleContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;

    public EntityFrameworkExampleContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
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
        ChangeTracker.SetAuditProperties(_currentUserService);
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        ChangeTracker.SetAuditProperties(_currentUserService);
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ChangeTracker.SetAuditProperties(_currentUserService);
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ChangeTracker.SetAuditProperties(_currentUserService);
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}