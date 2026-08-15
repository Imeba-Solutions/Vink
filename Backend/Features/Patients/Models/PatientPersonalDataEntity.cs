using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Patients.Models;

[Table("PATIENTS_PERSONAL_DATA")]
public class PatientPersonalDataEntity
{
    [Key]
    [Column("patient_id")]
    public int PatientId { get; set; }
    
    [ForeignKey(nameof(PatientId))]
    public PatientEntity? Patient { get; set; }

    [Column("first_name")]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(100)]
    public string? LastName { get; set; }

    [Column("national_id")]
    [StringLength(50)]
    public string? NationalId { get; set; }

    [Column("date_of_birth")]
    public DateTime? DateOfBirth { get; set; }

    [Column("primary_phone")]
    [StringLength(50)]
    public string? PrimaryPhone { get; set; }

    [Column("contact_email")]
    [StringLength(255)]
    public string? ContactEmail { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("emergency_contact_name")]
    [StringLength(150)]
    public string? EmergencyContactName { get; set; }

    [Column("emergency_contact_phone")]
    [StringLength(50)]
    public string? EmergencyContactPhone { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
