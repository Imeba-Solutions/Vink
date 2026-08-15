using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Appointments.Models;

[Table("APPOINTMENT_STATUS")]
public class AppointmentStatusEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("status_name")]
    [StringLength(50)]
    public string StatusName { get; set; } = string.Empty;
}
