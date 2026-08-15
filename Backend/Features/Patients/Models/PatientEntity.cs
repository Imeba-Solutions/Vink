using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Features.Shared;
using Backend.Features.Users.Models;

namespace Backend.Features.Patients.Models;

[Table("PATIENTS")]
public class PatientEntity : IAuditableEntity, ISoftDelete
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("assigned_psychologist_id")]
    public int? AssignedPsychologistId { get; set; }
    
    [ForeignKey(nameof(AssignedPsychologistId))]
    public UserEntity? AssignedPsychologist { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    public PatientPersonalDataEntity? PersonalData { get; set; }
}
