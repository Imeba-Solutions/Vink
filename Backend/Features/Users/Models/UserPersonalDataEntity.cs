using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Users.Models;

[Table("USERS_PERSONAL_DATA")]
public class UserPersonalDataEntity
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public UserEntity? User { get; set; }

    [Column("first_name")]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(100)]
    public string? LastName { get; set; }

    [Column("national_id")]
    [StringLength(50)]
    public string? NationalId { get; set; }

    [Column("phone_number")]
    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [Column("license_number")]
    [StringLength(100)]
    public string? LicenseNumber { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
