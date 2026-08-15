namespace Backend.Features.Appointments.Interfaces;
using Backend.Features.Appointments.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentEntity>> GetAllAsync();
    Task<AppointmentEntity?> GetByIdAsync(int id);
    Task<AppointmentEntity> AddAsync(AppointmentEntity entity);
    Task UpdateAsync(AppointmentEntity entity);
    Task DeleteAsync(int id);
}
