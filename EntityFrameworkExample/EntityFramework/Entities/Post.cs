using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkExample.Entities;

[Table("Posts")]
public class Post : EntityBase
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Required]
    [MaxLength(100)]
    public string Url { get; set; }

    public bool IsDraft { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }

    [ForeignKey(nameof(BlogId))]
    public Blog Blog { get; set; }
}
