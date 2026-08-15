using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Features.Shared;
using Backend.Features.Users.Models;
using Backend.Features.Patients.Models;
using Backend.Features.Appointments.Models;

namespace Backend.Features.MedicalRecords.Models;

[Table("MEDICAL_RECORDS")]
public class MedicalRecordEntity : IAuditableEntity, ISoftDelete
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }
    
    [ForeignKey(nameof(PatientId))]
    public PatientEntity? Patient { get; set; }

    [Column("psychologist_id")]
    public int PsychologistId { get; set; }
    
    [ForeignKey(nameof(PsychologistId))]
    public UserEntity? Psychologist { get; set; }

    [Column("appointment_id")]
    public int? AppointmentId { get; set; }
    
    [ForeignKey(nameof(AppointmentId))]
    public AppointmentEntity? Appointment { get; set; }

    [Column("session_notes")]
    public string? SessionNotes { get; set; }

    [Column("diagnosis_code")]
    [StringLength(50)]
    public string? DiagnosisCode { get; set; }

    [Column("is_private")]
    public bool IsPrivate { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
