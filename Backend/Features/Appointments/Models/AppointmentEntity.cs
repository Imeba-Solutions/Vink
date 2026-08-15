using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Features.Shared;
using Backend.Features.Users.Models;
using Backend.Features.Patients.Models;

namespace Backend.Features.Appointments.Models;

[Table("APPOINTMENTS")]
public class AppointmentEntity : IAuditableEntity, ISoftDelete
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

    [Column("status_id")]
    public int StatusId { get; set; }
    
    [ForeignKey(nameof(StatusId))]
    public AppointmentStatusEntity? Status { get; set; }

    [Column("appointment_date")]
    public DateTime AppointmentDate { get; set; }

    [Column("start_time")]
    public TimeSpan StartTime { get; set; }

    [Column("end_time")]
    public TimeSpan EndTime { get; set; }

    [Column("consultation_reason")]
    public string? ConsultationReason { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
