using EntityFrameworkExample.Authentication;
using EntityFrameworkExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFrameworkExample.Extensions;

public static class ChangeTrackerExtensions
{
    public static void SetAuditProperties(this ChangeTracker changeTracker, ICurrentUserService currentUserService)
    {
        changeTracker.DetectChanges();
        IEnumerable<EntityEntry> entities =
            changeTracker
                .Entries()
                .Where(t => t.Entity is IEntityBase &&
                (
                    t.State == EntityState.Deleted
                    || t.State == EntityState.Added
                    || t.State == EntityState.Modified
                ));

        if (entities.Any())
        {
            DateTimeOffset timestamp = DateTimeOffset.UtcNow;

            string user = currentUserService.GetCurrentUser().LoginName;

            foreach (EntityEntry entry in entities)
            {
                IEntityBase entity = (IEntityBase)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedOn = timestamp;
                        entity.CreatedBy = user;
                        entity.UpdatedOn = timestamp;
                        entity.UpdatedBy = user;
                        break;
                    case EntityState.Modified:
                        entity.UpdatedOn = timestamp;
                        entity.UpdatedBy = user;
                        break;
                    case EntityState.Deleted:
                        entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
        }
    }
}