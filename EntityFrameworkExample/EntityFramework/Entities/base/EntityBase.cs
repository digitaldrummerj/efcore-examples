using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkExample.Entities;

public abstract class EntityBase : IEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }

    public string UpdatedBy { get; set; }
}
