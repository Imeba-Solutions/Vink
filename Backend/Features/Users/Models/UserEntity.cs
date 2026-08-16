using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Features.Shared;
using Backend.Features.Roles.Models;

namespace Backend.Features.Users.Models;

[Table("USERS")]
public class UserEntity : IAuditableEntity, ISoftDelete
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }
    
    [ForeignKey(nameof(RoleId))]
    public RoleEntity? Role { get; set; }

    [Required]
    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    public UserPersonalDataEntity? PersonalData { get; set; }
}
