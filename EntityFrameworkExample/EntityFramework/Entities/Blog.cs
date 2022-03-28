using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkExample.Entities;

[Table("Blogs")]
public class Blog : EntityBase
{
    [Required]
    [MaxLength(255)]

    public string Name { get; set; }

    [Required]
    [MaxLength(25)]
    public Status Status { get; set; }

    [Required]
    [MaxLength(2048)]

    public string Url { get; set; }

    [InverseProperty(nameof(Blog))]
    public List<Post> Posts { get; set; } = new List<Post>();
}