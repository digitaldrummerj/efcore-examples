namespace EntityFrameworkExample.Entities;
public interface IEntityBase
{
    int Id { get; set; }

    bool IsDeleted { get; set; }
}
