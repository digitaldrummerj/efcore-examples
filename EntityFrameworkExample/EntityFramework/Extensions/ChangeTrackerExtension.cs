using EntityFrameworkExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFrameworkExample.Extensions;

public static class ChangeTrackerExtensions
{
    public static void SetAuditProperties(this ChangeTracker changeTracker)
    {
        changeTracker.DetectChanges();
        IEnumerable<EntityEntry> entities =
            changeTracker
                .Entries()
                .Where(t => t.Entity is IEntityBase && t.State == EntityState.Deleted);

        if (entities.Any())
        {
            foreach(EntityEntry entry in entities)
            {
                IEntityBase entity = (IEntityBase)entry.Entity;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}