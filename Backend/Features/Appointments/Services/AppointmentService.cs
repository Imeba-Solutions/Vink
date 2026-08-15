namespace Backend.Features.Appointments.Services;
using Backend.Features.Appointments.Interfaces;
using Backend.Features.Appointments.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repository;

    public AppointmentService(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AppointmentEntity>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<AppointmentEntity?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<AppointmentEntity> AddAsync(AppointmentEntity entity) => await _repository.AddAsync(entity);

    public async Task UpdateAsync(AppointmentEntity entity) => await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
