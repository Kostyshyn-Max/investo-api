using System.ComponentModel.DataAnnotations.Schema;

namespace Investo.DataAccess.Entities;

[Table("user_roles")]
public class UserRole : AbstractEntity<int>
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}
