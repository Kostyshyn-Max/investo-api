using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Investo.DataAccess.Entities;

[Table("users")]
public class User : AbstractEntity<Guid>
{
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;

    [Column("password_salt")]
    public string PasswordSalt { get; set; } = string.Empty;

    [Column("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;

    [Column("refresh_token_expire_date")]
    public string RefreshTokenExpireDate { get; set; } = string.Empty;

    [Column("user_role_id")]
    [ForeignKey(nameof(UserRole))]
    public int UserRoleId { get; set; }

    public UserRole UserRole { get; set; }
}
